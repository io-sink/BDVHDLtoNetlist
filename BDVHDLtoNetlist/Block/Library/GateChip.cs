using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BDVHDLtoNetlist.Block.Gate.LogicGate;

namespace BDVHDLtoNetlist.Block.Library
{
    class GateChip : IChip
    {
        public GateType gateType { get; }

        // ゲートのシグナル -> チップのピン
        public Dictionary<ISignal, ISignal>[] portNameMappings { get; }

        // チップのピン -> 信号名
        public Dictionary<ISignal, SignalName> constAssignMappings { get; }

        public bool defaultHigh { get; }

        private static HashSet<GateType> activeHighGates = new HashSet<GateType>() { GateType.AND, GateType.NAND };

        private GateChip(
            GateType gateType, 
            Dictionary<ISignal, ISignal>[] portNameMappings, 
            Dictionary<ISignal, SignalName> constAssignMappings, 
            bool defaultHigh = false)
        {
            this.gateType = gateType;
            this.portNameMappings = portNameMappings;
            this.constAssignMappings = constAssignMappings;
            this.defaultHigh = defaultHigh;
        }

        public static GateChip ImportFromFile(string fileName)
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
            foreach (var logicGate in objects.logicGates)
            {
                if (logicGate.gateType != gateType)
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

            return new GateChip(gateType, portNameMappings.ToArray(), constAssignMapping, activeHighGates.Contains(gateType));
        }

        public void Print()
        {
            Console.WriteLine(this.gateType);
            for(int i = 0; i < this.portNameMappings.Length; ++i)
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
