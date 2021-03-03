using BDVHDLtoNetlist.Block.Component;
using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Block.Library
{
    class ComponentChip : IChip
    {
        public ComponentPrototype componentPrototype { get; }

        // ゲートのシグナル -> チップのピン
        public Dictionary<ISignal, ISignal>[] portNameMappings { get; }

        // チップのピン -> 信号名
        public Dictionary<ISignal, SignalName> constAssignMappings { get; }


        private ComponentChip(
            ComponentPrototype componentPrototype,
            Dictionary<ISignal, ISignal>[] portNameMappings,
            Dictionary<ISignal, SignalName> constAssignMappings)
        {
            this.componentPrototype = componentPrototype;
            this.portNameMappings = portNameMappings;
            this.constAssignMappings = constAssignMappings;
        }

        public static ComponentChip ImportFromFile(string fileName)
        {
            var portNameMappings = new List<Dictionary<ISignal, ISignal>>();
            var constAssignMapping = new Dictionary<ISignal, SignalName>();

            string program = System.IO.File.ReadAllText(fileName);
            var objects = (new Parser.MyParser()).Parse(program);

            if (objects.components.Count == 0 ||
                objects.componentDeclarations.Count == 1 ||
                objects.logicGates.Count > 0)
                throw new Exception("");

            // チップの入力信号
            var inPortSet = new HashSet<ISignal>(objects.signalTable.Values.Where(
                x => x.mode == SignalMode.IN && x.GetType() == typeof(StdLogic)));

            // チップの出力信号
            var outPortSet = new HashSet<ISignal>(objects.signalTable.Values.Where(
                x => x.mode == SignalMode.OUT && x.GetType() == typeof(StdLogic)));

            // チップの出力信号に直結した信号
            var outPortAssignment = new Dictionary<ISignal, ISignal>();
            foreach (var pair in objects.assignments.Where(
                x => x.Key.mode == SignalMode.OUT && x.Key.GetType() == typeof(StdLogic)))
                outPortAssignment.Add(pair.Value, pair.Key);

            // ポートの対応関係を作成
            ComponentPrototype componentPrototype = objects.components[0].prototype;
            foreach (var component in objects.components)
            {
                if (component.prototype != componentPrototype)
                    throw new Exception("");

                var portNameMap = new Dictionary<ISignal, ISignal>();


                foreach (var componentSignal in component.portMap.Keys)
                    if(componentSignal.mode == SignalMode.IN)
                    {
                        if (!inPortSet.Contains(component.portMap[componentSignal]))
                            throw new Exception("");
                        inPortSet.Remove(component.portMap[componentSignal]);

                        portNameMap.Add(componentSignal, component.portMap[componentSignal]);
                    }
                    else if(componentSignal.mode == SignalMode.OUT)
                    {
                        if (!outPortSet.Contains(component.portMap[componentSignal]))
                            throw new Exception("");
                        outPortSet.Remove(component.portMap[componentSignal]);

                        portNameMap.Add(componentSignal, component.portMap[componentSignal]);
                    }


                portNameMappings.Add(portNameMap);
            }

            // チップの入力でコンポネントの入力以外に接続するもの
            foreach (var inPort in inPortSet)
                if (inPort.attribute.ContainsKey("const_assign"))
                {
                    var constValue = inPort.attribute["const_assign"];
                    if (constValue is string)
                        constAssignMapping[inPort] = SignalName.Parse((string)constValue);
                }

            return new ComponentChip(componentPrototype, portNameMappings.ToArray(), constAssignMapping);
        }

        public void Print()
        {
            Console.WriteLine(this.componentPrototype.name);
            for (int i = 0; i < this.portNameMappings.Length; ++i)
            {
                Console.WriteLine("{0}: ", i);
                foreach (var pair in this.portNameMappings[i])
                    Console.WriteLine("\t{0} -> {1}", pair.Key, pair.Value);
            }

            foreach (var pair in this.constAssignMappings)
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
        }
    }
}
