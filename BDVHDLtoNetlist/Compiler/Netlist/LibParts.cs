using BDVHDLtoNetlist.Block.Chip;
using BDVHDLtoNetlist.Block.Component;
using BDVHDLtoNetlist.Block.Gate;
using BDVHDLtoNetlist.Block.Signal;
using BDVHDLtoNetlist.Parser.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Compiler.Netlist
{
    class LibParts
    {
        public IChipDefinition chip { get; }

        public LibParts(
            ComponentChipDefinition componentChip, 
            List<Component> components, 
            Dictionary<StdLogic, Net> netMap, 

            DeclaredObjectContainer design,
            Dictionary<StdLogic, Net> representingNet)
        {
            if (componentChip.componentCount < components.Count)
                throw new Exception();

            this.chip = componentChip;
            
            for (int i = 0; i < components.Count; ++i)
                foreach (var portPair in components[i].portMap)
                {
                    if (!(portPair.Value is StdLogic))
                        throw new Exception("Component port must be STD_LOGIC");

                    var netSignal = netMap[(StdLogic)portPair.Value];
                    var chipSignal = componentChip.portNameMappings[i][portPair.Key];

                    if (!chipSignal.attribute.ContainsKey("pin_assign"))
                        throw new Exception(string.Format("{0}@{1} has no pin assignment", chipSignal, componentChip.componentPrototype.name));

                    netSignal.adjacentNodes.Add(new Node(this, (int)chipSignal.attribute["pin_assign"]));
                }

            ProcesConstAssign(componentChip.constAssignMappings, this, design, representingNet);

        }

        public LibParts(
            GateChipDefinition gateChip, 
            List<LogicGate> gates, 
            Dictionary<StdLogic, Net> netMap,

            DeclaredObjectContainer design,
            Dictionary<StdLogic, Net> representingNet)
        {
            if (gateChip.gateCount < gates.Count)
                throw new Exception();

            this.chip = gateChip;

            for (int i = 0; i < gates.Count; ++i)
            {
                for (int j = 0; j < gates[i].inputSignals.Count; ++j)
                {
                    var netInputSignal = netMap[(StdLogic)gates[i].inputSignals[j]];
                    var chipInputSignal = gateChip.portNameMappings[i][new StdLogic(new SignalName(".in" + j))];
                    if (!chipInputSignal.attribute.ContainsKey("pin_assign"))
                        throw new Exception(string.Format("{0}@{1}{2} has no pin assignment", chipInputSignal, gateChip.gateType, gateChip.gateWidth));
                    netInputSignal.adjacentNodes.Add(new Node(this, (int)chipInputSignal.attribute["pin_assign"]));
                }

                for (int j = gates[i].inputSignals.Count; j < gateChip.gateWidth; ++i)
                {
                    var chipInputSignal = gateChip.portNameMappings[i][new StdLogic(new SignalName(".in" + j))];
                    if (!chipInputSignal.attribute.ContainsKey("pin_assign"))
                        throw new Exception(string.Format("{0}@{1}{2} has no pin assignment", chipInputSignal, gateChip.gateType, gateChip.gateWidth));

                    // ゲートの余った入力
                    if (gateChip.defaultHigh)
                    {
                        if (!design.signalTable.ContainsKey("VCC") || !(design.signalTable["VCC"] is StdLogic))
                            throw new Exception();
                        var vccSignal = (StdLogic)design.signalTable["VCC"];
                        netMap[vccSignal].adjacentNodes.Add(new Node(this, (int)chipInputSignal.attribute["pin_assign"]));
                    }
                    else
                    {
                        if (!design.signalTable.ContainsKey("GND") || !(design.signalTable["GND"] is StdLogic))
                            throw new Exception();
                        var groundSignal = (StdLogic)design.signalTable["GND"];
                        netMap[groundSignal].adjacentNodes.Add(new Node(this, (int)chipInputSignal.attribute["pin_assign"]));
                    }
                }

                var netOutputSignal = netMap[(StdLogic)gates[i].outputSignal];
                var chipOutputSignal = gateChip.portNameMappings[i][new StdLogic(new SignalName(".out"))];

                if (!chipOutputSignal.attribute.ContainsKey("pin_assign"))
                    throw new Exception(string.Format("{0}@{1}{2} has no pin assignment", chipOutputSignal, gateChip.gateType, gateChip.gateWidth));
                netOutputSignal.adjacentNodes.Add(new Node(this, (int)chipOutputSignal.attribute["pin_assign"]));
            }

            ProcesConstAssign(gateChip.constAssignMappings, this, design, representingNet);
        }

        // チップのconst_assignを処理
        void ProcesConstAssign(
            Dictionary<ISignal, SignalName> constAssignMappings, 
            LibParts libParts, 
            
            DeclaredObjectContainer design,
            Dictionary<StdLogic, Net> representingNet)
        {
            foreach (var constAssign in constAssignMappings)
            {
                var assignedSignalName = constAssign.Value;
                if (!design.signalTable.ContainsKey(assignedSignalName.baseName))
                    throw new Exception();

                var assignedSignal = design.signalTable[assignedSignalName];
                if (!(assignedSignal is StdLogic))
                    throw new Exception();

                var assignedNet = representingNet[(StdLogic)assignedSignal];

                if (!constAssign.Key.attribute.ContainsKey("pin_assign"))
                    throw new Exception();

                int portPin = (int)constAssign.Key.attribute["pin_assign"];

                assignedNet.adjacentNodes.Add(new Node(libParts, portPin));
            }
        }



    }
}
