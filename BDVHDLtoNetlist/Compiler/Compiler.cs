using BDVHDLtoNetlist.Block.Chip;
using BDVHDLtoNetlist.Block.Component;
using BDVHDLtoNetlist.Block.Gate;
using BDVHDLtoNetlist.Block.Signal;
using BDVHDLtoNetlist.Compiler.Netlist;
using BDVHDLtoNetlist.Exceptions;
using BDVHDLtoNetlist.Parser.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Compiler
{
    class Compiler
    {
        public Dictionary<StdLogic, Net> representingNet { get; set; }

        public List<NetComponents> netComponents { get; set; }

        public Dictionary<IChipDefinition, int> resComponentCount { get; set; }

        public void Compile(DeclaredObjectContainer design, List<IChipDefinition> chips)
        {
            this.representingNet = new Dictionary<StdLogic, Net>();
            this.resComponentCount = new Dictionary<IChipDefinition, int>();

            foreach (ISignal signal in design.signalTable.Values)
                if (signal is StdLogic)
                    this.representingNet[(StdLogic)signal] = new Net(signal.name.ToString());
                else if (signal is StdLogicVector) 
                {
                    var vector = (StdLogicVector)signal;
                    for (int i = 0; i < vector.size; ++i)
                    {
                        var stdLogic = vector.GetLogic(vector.stRange + i);
                        this.representingNet[stdLogic] = new Net(stdLogic.name.ToString());
                    }
                }

            // 代入されたネットの統一
            foreach (var assignment in design.assignments)
                if (assignment.Key is StdLogic && assignment.Value is StdLogic)
                    this.representingNet[(StdLogic)assignment.Key] = this.representingNet[(StdLogic)assignment.Value];

                else if (assignment.Key is StdLogicVector && assignment.Value is StdLogicVector)
                {
                    var leftVector = (StdLogicVector)assignment.Key;
                    var rightVector = (StdLogicVector)assignment.Value;

                    if (leftVector.size != rightVector.size)
                        throw new Exception();

                    for(int i = 0; i < leftVector.size; ++i)
                        this.representingNet[leftVector.GetLogic(leftVector.stRange + i)] = 
                            this.representingNet[rightVector.GetLogic(rightVector.stRange + i)];
                }
                else
                    throw new Exception();


            // 使用されている全てのチップが宣言されているか
            var componentChips = new Dictionary<ComponentPrototype, ComponentChipDefinition>();
            var gateChips = new Dictionary<LogicGate.GateType, SortedDictionary<int, GateChipDefinition>>();
            foreach (var chipDeclaration in chips)
                if (chipDeclaration is ComponentChipDefinition)
                    componentChips[((ComponentChipDefinition)chipDeclaration).componentPrototype] = (ComponentChipDefinition)chipDeclaration;
                else if (chipDeclaration is GateChipDefinition)
                {
                    var gateChipDefinition = (GateChipDefinition)chipDeclaration;
                    if (!gateChips.ContainsKey(gateChipDefinition.gateType))
                        gateChips[gateChipDefinition.gateType] = new SortedDictionary<int, GateChipDefinition>();
                    gateChips[gateChipDefinition.gateType][gateChipDefinition.gateWidth] = gateChipDefinition;
                }

            foreach (var component in design.components)
                if (!componentChips.ContainsKey(component.prototype))
                    throw new CompilerException(
                        string.Format(@"No component chip definition was found for component ""{0}""", component.prototype.name));

            foreach (var gate in design.logicGates)
                if (!gateChips.ContainsKey(gate.gateType))
                    throw new CompilerException(
                        string.Format(@"No gate chip definition was found for gate ""{0}""", gate.gateType));


            // 回路パーツに変換
            this.netComponents = new List<NetComponents>();
            var componentQueue = new Dictionary<ComponentPrototype, List<Component>>();
            var gateQueue = new Dictionary<LogicGate.GateType, List<LogicGate>>();

            foreach (var component in design.components)
            {
                if (!componentQueue.ContainsKey(component.prototype))
                    componentQueue[component.prototype] = new List<Component>();
                componentQueue[component.prototype].Add(component);
            }
            foreach (var gate in design.logicGates)
            {
                if (!gateQueue.ContainsKey(gate.gateType))
                    gateQueue[gate.gateType] = new List<LogicGate>();
                gateQueue[gate.gateType].Add(gate);
            }

            // GNDを取得
            if (!design.signalTable.ContainsKey("GND") || !(design.signalTable["GND"] is StdLogic))
                throw new CompilerException(
                    string.Format(@"Signal ""{0}"" was not found in design", "GND"));

            var groundSignal = (StdLogic)design.signalTable["GND"];

            // コンポーネントのチップを作成
            foreach (var componentPrototype in componentQueue.Keys)
            {
                // コンポネントの名前で降順ソート
                componentQueue[componentPrototype].Sort((x, y) => 
                    (new ComponentNameComparer()).Compare(y.name, x.name));

                while (componentQueue[componentPrototype].Count > 0)
                {
                    int dequeueCount = Math.Min(componentQueue[componentPrototype].Count, componentChips[componentPrototype].componentCount);
                    var components = new List<Component>();

                    for (int i = 0; i < dequeueCount; ++i)
                    {
                        components.Add(componentQueue[componentPrototype].Last());
                        componentQueue[componentPrototype].RemoveAt(componentQueue[componentPrototype].Count - 1);
                    }

                    this.resComponentCount[componentChips[componentPrototype]] = componentChips[componentPrototype].componentCount - dequeueCount;

                    // 余ったコンポネントの入力ポートをGNDに固定，出力ポートに仮の信号を接続
                    for (int i = dequeueCount; i < componentChips[componentPrototype].componentCount; ++i)
                    {
                        var portMap = new Dictionary<ISignal, ISignal>();
                        foreach (var portSignal in componentPrototype.signals)
                            if (portSignal.Value.mode == SignalMode.IN)
                                portMap[portSignal.Value] = groundSignal;

                            else if(portSignal.Value.mode == SignalMode.OUT || portSignal.Value.mode == SignalMode.INOUT)
                            {
                                var tempSignal = new StdLogic(design.signalNameGenerator.getSignalName());
                                this.representingNet[tempSignal] = new Net(".temp");
                                portMap[portSignal.Value] = tempSignal;
                            }

                        components.Add(new Component("dummy", componentPrototype, portMap));
                    }
                    
                    var parts = new NetComponents(componentChips[componentPrototype], components, this.representingNet, design, this.representingNet);
                    this.netComponents.Add(parts);
                }
            }

            // ゲートのチップを作成
            foreach (var gateType in gateQueue.Keys)
            {
                int gateWidth = 0;
                var gatePool = new List<LogicGate>();
                gateQueue[gateType].Sort((x, y) => y.inputSignals.Count - x.inputSignals.Count);

                foreach (var gate in gateQueue[gateType])
                {
                    if (gatePool.Count == 0)
                    {
                        var gateWidthCandidate = gateChips[gateType].Keys.Where(x => x >= gate.inputSignals.Count);
                        if (gateWidthCandidate.Count() == 0)
                            throw new CompilerException(
                                string.Format(@"Gate {0}{1} is not defined", gateType, gate.inputSignals.Count));

                        gateWidth = gateWidthCandidate.First();
                    }

                    gatePool.Add(gate);

                    if(gatePool.Count == gateChips[gateType][gateWidth].gateCount)
                    {
                        this.resComponentCount[gateChips[gateType][gateWidth]] = 0;

                        var parts = new NetComponents(gateChips[gateType][gateWidth], gatePool, this.representingNet, design, this.representingNet);
                        this.netComponents.Add(parts);

                        gatePool.Clear();
                    }
                }

                if (gatePool.Count > 0)
                {
                    // 余ったゲートの入力をGNDに固定，出力に仮の信号を接続したゲートを追加
                    var groundSignals = new List<ISignal>();
                    for (int i = 0; i < gateWidth; ++i)
                        groundSignals.Add(groundSignal);


                    this.resComponentCount[gateChips[gateType][gateWidth]] = gateChips[gateType][gateWidth].gateCount - gatePool.Count;

                    for (int i = gatePool.Count; i < gateChips[gateType][gateWidth].gateCount; ++i)
                    {
                        var tempSignal = new StdLogic(design.signalNameGenerator.getSignalName());
                        this.representingNet[tempSignal] = new Net(".temp");
                        gatePool.Add(new LogicGate(gateType, groundSignals, tempSignal));
                    }

                    var parts = new NetComponents(gateChips[gateType][gateWidth], gatePool, this.representingNet, design, this.representingNet);
                    this.netComponents.Add(parts);
                }


            }

            
        }


    }
}
