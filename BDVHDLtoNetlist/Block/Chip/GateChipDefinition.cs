using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BDVHDLtoNetlist.Block.Gate.LogicGate;

namespace BDVHDLtoNetlist.Block.Chip
{
    class GateChipDefinition : IChipDefinition
    {
        public GateType gateType { get; }

        public int gateWidth { get; }

        // ゲートのシグナル -> チップのピン
        public Dictionary<ISignal, ISignal>[] portNameMappings { get; }

        public int gateCount { get { return portNameMappings.Length; } }

        // チップのピン -> 信号名
        public Dictionary<ISignal, SignalName> constAssignMappings { get; }

        public Dictionary<string, object> chipAttribute { get; }

        public bool defaultHigh { get; }

        private static HashSet<GateType> activeHighGates = new HashSet<GateType>() { GateType.AND, GateType.NAND };

        private GateChipDefinition(
            GateType gateType, 
            int gateWidth,
            Dictionary<ISignal, ISignal>[] portNameMappings, 
            Dictionary<ISignal, SignalName> constAssignMappings,
            Dictionary<string, object> chipAttribute, 
            bool defaultHigh = false)
        {
            this.gateType = gateType;
            this.gateWidth = gateWidth;
            this.portNameMappings = portNameMappings;
            this.constAssignMappings = constAssignMappings;
            this.chipAttribute = chipAttribute;
            this.defaultHigh = defaultHigh;
        }

        public static GateChipDefinition ImportFromFile(string fileName)
        {
            var portNameMappings = new List<Dictionary<ISignal, ISignal>>();
            var constAssignMapping = new Dictionary<ISignal, SignalName>();

            string program = System.IO.File.ReadAllText(fileName);
            var objects = (new Parser.MyParser()).Parse(program);

            if (objects.components.Count > 0 || 
                objects.componentDeclarations.Count > 1 || 
                objects.logicGates.Count == 0)
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
            GateType gateType = objects.logicGates[0].gateType;
            int gateWidth = objects.logicGates[0].inputSignals.Count;
            foreach (var logicGate in objects.logicGates)
            {
                if (logicGate.gateType != gateType || logicGate.inputSignals.Count != gateWidth)
                    throw new Exception("");

                var portNameMap = new Dictionary<ISignal, ISignal>();

                for(int i = 0; i < logicGate.inputSignals.Count; ++i)
                {
                    if (!inPortSet.Contains(logicGate.inputSignals[i]))
                        throw new Exception("");
                    inPortSet.Remove(logicGate.inputSignals[i]);

                    portNameMap.Add(new StdLogic(new SignalName(".in" + i)), logicGate.inputSignals[i]);
                }

                if (!outPortAssignment.ContainsKey(logicGate.outputSignal) || 
                    !outPortSet.Contains(outPortAssignment[logicGate.outputSignal]))
                    throw new Exception("");

                var outPort = outPortAssignment[logicGate.outputSignal];
                outPortSet.Remove(outPort);
                portNameMap.Add(new StdLogic(new SignalName(".out")), outPort);

                portNameMappings.Add(portNameMap);
            }

            // チップの入力でゲートの入力以外に接続するもの
            foreach (var inPort in inPortSet)
                if (inPort.attribute.ContainsKey("const_assign"))
                {
                    var constValue = inPort.attribute["const_assign"];
                    if(constValue is string)
                        constAssignMapping[inPort] = SignalName.Parse((string)constValue);
                }

            return new GateChipDefinition(gateType, gateWidth, portNameMappings.ToArray(), constAssignMapping, objects.entityAttribute, activeHighGates.Contains(gateType));
        }

        public void Print()
        {
            Console.WriteLine(this.gateType);

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
