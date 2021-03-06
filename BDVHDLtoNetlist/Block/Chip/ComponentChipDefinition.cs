using BDVHDLtoNetlist.Block.Component;
using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Block.Chip
{
    class ComponentChipDefinition : IChipDefinition
    {
        public ComponentPrototype componentPrototype { get; }

        // ゲートのシグナル -> チップのピン
        public Dictionary<ISignal, ISignal>[] portNameMappings { get; }

        public int componentCount { get { return portNameMappings.Length; } }

        // チップのピン -> 信号名
        public Dictionary<ISignal, SignalName> constAssignMappings { get; }

        public Dictionary<string, object> chipAttribute { get; }

        private ComponentChipDefinition(
            ComponentPrototype componentPrototype,
            Dictionary<ISignal, ISignal>[] portNameMappings,
            Dictionary<ISignal, SignalName> constAssignMappings,
            Dictionary<string, object> chipAttribute)
        {
            this.componentPrototype = componentPrototype;
            this.portNameMappings = portNameMappings;
            this.constAssignMappings = constAssignMappings;
            this.chipAttribute = chipAttribute;
        }

        public static ComponentChipDefinition ImportFromFile(string fileName)
        {
            var portNameMappings = new List<Dictionary<ISignal, ISignal>>();
            var constAssignMapping = new Dictionary<ISignal, SignalName>();

            string program = System.IO.File.ReadAllText(fileName);
            var objects = (new Parser.MyParser()).Parse(program);

            if (objects.components.Count == 0 ||
                objects.componentDeclarations.Count == 1 ||
                objects.logicGates.Count > 0)
                return null;

            // チップの入出力信号
            var portSet = new HashSet<ISignal>(objects.signalTable.Values.Where(
                x => (x.mode == SignalMode.IN || x.mode == SignalMode.OUT || x.mode == SignalMode.INOUT) && 
                x.GetType() == typeof(StdLogic)));

            // ポートの対応関係を作成
            ComponentPrototype componentPrototype = objects.components[0].prototype;
            foreach (var component in objects.components)
            {
                if (component.prototype != componentPrototype)
                    throw new Exception("");

                var portNameMap = new Dictionary<ISignal, ISignal>();

                foreach (var componentSignal in component.portMap.Keys)
                    if(componentSignal.mode == SignalMode.IN || 
                        componentSignal.mode == SignalMode.OUT ||
                        componentSignal.mode == SignalMode.INOUT)
                    {
                        if (!portSet.Contains(component.portMap[componentSignal]))
                            throw new Exception("");
                        portSet.Remove(component.portMap[componentSignal]);

                        portNameMap.Add(componentSignal, component.portMap[componentSignal]);
                    }

                portNameMappings.Add(portNameMap);
            }

            // チップの入力でコンポネントの入出力以外に接続するもの
            foreach (var port in objects.signalTable.Values)
                if ((port.mode == SignalMode.IN || port.mode == SignalMode.INOUT) &&
                    portSet.Contains(port) && /* まだ接続されていない */
                    port.attribute.ContainsKey("const_assign"))
                {
                    var constValue = port.attribute["const_assign"];
                    if (constValue is string)
                        constAssignMapping[port] = SignalName.Parse((string)constValue);
                }

            return new ComponentChipDefinition(componentPrototype, portNameMappings.ToArray(), constAssignMapping, objects.entityAttribute);
        }

        public void Print()
        {
            Console.WriteLine(this.componentPrototype.name);

            foreach (var pair in this.chipAttribute)
                Console.WriteLine("[ATTRIBUTE] {0} -> {1}", pair.Key, pair.Value.ToString());

            for (int i = 0; i < this.portNameMappings.Length; ++i)
            {
                Console.WriteLine("[PORT] {0}: ", i);
                foreach (var pair in this.portNameMappings[i])
                    Console.WriteLine("\t{0} -> {1}", pair.Key, pair.Value);
            }

            foreach (var pair in this.constAssignMappings)
                Console.WriteLine("[CONST] {0} -> {1}", pair.Key, pair.Value);
        }
    }
}
