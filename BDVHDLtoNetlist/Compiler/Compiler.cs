using BDVHDLtoNetlist.Block.Chip;
using BDVHDLtoNetlist.Block.Component;
using BDVHDLtoNetlist.Block.Gate;
using BDVHDLtoNetlist.Block.Signal;
using BDVHDLtoNetlist.Compiler.Netlist;
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

        public List<LibParts> libParts { get; set; }

        private DeclaredObjectContainer design;

        public void Compile(DeclaredObjectContainer design, List<IChipDefinition> chips)
        {
            this.representingNet = new Dictionary<StdLogic, Net>();

            foreach (ISignal signal in design.signalTable.Values)
                if (signal is StdLogic)
                    this.representingNet[(StdLogic)signal] = new Net();
                else if (signal is StdLogicVector) 
                {
                    var vector = (StdLogicVector)signal;
                    for (int i = 0; i < vector.size; ++i)
                        this.representingNet[vector.GetLogic(vector.stRange + i)] = new Net();
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
                    throw new Exception("No component chip definition found: " + component.prototype.name);
            foreach (var gate in design.logicGates)
                if (!gateChips.ContainsKey(gate.gateType))
                    throw new Exception("No gate chip definition found: " + gate.gateType);


            // 回路パーツに変換
            this.libParts = new List<LibParts>();
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
                throw new Exception();
            var groundSignal = (StdLogic)design.signalTable["GND"];


            foreach (var componentPrototype in componentQueue.Keys)
            {
                while (componentQueue[componentPrototype].Count > 0)
                {
                    int dequeueCount = Math.Min(componentQueue[componentPrototype].Count, componentChips[componentPrototype].componentCount);
                    var components = new List<Component>();

                    for (int i = 0; i < dequeueCount; ++i)
                    {
                        components.Add(componentQueue[componentPrototype].First());
                        componentQueue[componentPrototype].RemoveAt(componentQueue[componentPrototype].Count - 1);
                    }

                    
                    // 空いた入力ポートをGNDに固定
                    for (int i = dequeueCount; i < componentChips[componentPrototype].componentCount; ++i)
                    {
                        var portMap = new Dictionary<ISignal, ISignal>();
                        foreach (var inPortSignal in componentPrototype.signals)
                            if (inPortSignal.Value.mode == SignalMode.IN || inPortSignal.Value.mode == SignalMode.INOUT)
                                portMap[inPortSignal.Value] = groundSignal;
                            else
                            {
                                var tempSignal = new StdLogic(design.signalNameGenerator.getSignalName());
                                this.representingNet[tempSignal] = new Net();
                                portMap[inPortSignal.Value] = tempSignal;
                            }

                        components.Add(new Component("dummy", componentPrototype, portMap));
                    }
                    

                    var parts = new LibParts(componentChips[componentPrototype], components, this.representingNet, design, this.representingNet);
                    this.libParts.Add(parts);

                }
            }

            foreach (var gateType in gateQueue.Keys)
            {
                int gateWidth = 0;
                var gatePool = new List<LogicGate>();

                gateQueue[gateType].Sort((x, y) => y.inputSignals.Count - x.inputSignals.Count);

                foreach (var gate in gateQueue[gateType])
                {
                    if(gatePool.Count == 0)
                        gateWidth = gateChips[gateType].Keys.Where(x => x >= gate.inputSignals.Count).First();

                    gatePool.Add(gate);

                    if(gatePool.Count == gateChips[gateType][gateWidth].gateCount)
                    {
                        var parts = new LibParts(gateChips[gateType][gateWidth], gatePool, this.representingNet, design, this.representingNet);
                        this.libParts.Add(parts);

                        gatePool.Clear();
                    }
                }

                
                // 余ったゲートの入力をGNDに固定
                var groundSignals = new List<ISignal>();
                for (int i = 0; i < gateWidth; ++i)
                    groundSignals.Add(groundSignal);
                for (int i = gatePool.Count; i < gateChips[gateType][gateWidth].gateCount; ++i)
                {
                    var tempSignal = new StdLogic(design.signalNameGenerator.getSignalName());
                    this.representingNet[tempSignal] = new Net();
                    gatePool.Add(new LogicGate(gateType, groundSignals, tempSignal));
                }
                

                if (gatePool.Count > 0)
                {
                    var parts = new LibParts(gateChips[gateType][gateWidth], gatePool, this.representingNet, design, this.representingNet);
                    this.libParts.Add(parts);
                }



            }

            
        }


    }
}
