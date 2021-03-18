using BDVHDLtoNetlist.Block.Chip;
using BDVHDLtoNetlist.Block.Component;
using BDVHDLtoNetlist.Block.Gate;
using BDVHDLtoNetlist.Block.Signal;
using BDVHDLtoNetlist.Exceptions;
using BDVHDLtoNetlist.Parser.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Compiler.Netlist
{
    class NetComponents
    {
        public IChipDefinition chip { get; }

        public int id { get; }
        public string name { get { return string.Format("U{0}", this.id); } }

        public string componentName { get; } = "";

        private static int count = 0;

        public NetComponents(
            ComponentChipDefinition componentChip, 
            List<Component> components, 
            Dictionary<StdLogic, Net> netMap, 

            DeclaredObjectContainer design,
            Dictionary<StdLogic, Net> representingNet)
        {
            if (componentChip.componentCount < components.Count)
                throw new Exception();

            this.chip = componentChip;
            this.id = ++NetComponents.count;

            if (components.Count() == 1)
                this.componentName = components[0].name;

            for (int i = 0; i < components.Count; ++i)
                foreach (var portPair in components[i].portMap)
                {
                    var chipSignal = componentChip.portNameMappings[i][portPair.Key];

                    if (!(portPair.Value is StdLogic))
                        throw new CompilerException(
                            string.Format(@"Port signal ""{0}"" of chip ""{1}"" must be STD_LOGIC",
                            chipSignal.name, componentChip.chipName));

                    var netSignal = netMap[(StdLogic)portPair.Value];

                    if (!chipSignal.attribute.ContainsKey("pin_assign"))
                        throw new CompilerException(
                            string.Format(@"Port signal ""{0}"" of chip ""{1}"" does not have attribute ""pin_assignment""",
                            chipSignal.name, componentChip.chipName));

                    netSignal.adjacentNodes.Add(new Node(this, (int)chipSignal.attribute["pin_assign"]));
                }

            ProcesConstAssign(this, design, representingNet);
        }

        public NetComponents(
            GateChipDefinition gateChip, 
            List<LogicGate> gates, 
            Dictionary<StdLogic, Net> netMap,

            DeclaredObjectContainer design,
            Dictionary<StdLogic, Net> representingNet)
        {
            if (gateChip.gateCount < gates.Count)
                throw new Exception();

            this.chip = gateChip;
            this.id = ++NetComponents.count;

            for (int i = 0; i < gates.Count; ++i)
            {
                for (int j = 0; j < gates[i].inputSignals.Count; ++j)
                {
                    var netInputSignal = netMap[(StdLogic)gates[i].inputSignals[j]];
                    var chipInputSignal = gateChip.portNameMappings[i][new StdLogic(new SignalName(".in" + j))];
                    if (!chipInputSignal.attribute.ContainsKey("pin_assign"))
                        throw new CompilerException(
                            string.Format(@"Port signal ""{0}"" of chip ""{1}"" does not have attribute ""pin_assignment""",
                            chipInputSignal.name, gateChip.chipName));

                    netInputSignal.adjacentNodes.Add(new Node(this, (int)chipInputSignal.attribute["pin_assign"]));
                }

                for (int j = gates[i].inputSignals.Count; j < gateChip.gateWidth; ++j)
                {
                    var chipInputSignal = gateChip.portNameMappings[i][new StdLogic(new SignalName(".in" + j))];
                    if (!chipInputSignal.attribute.ContainsKey("pin_assign"))
                        throw new CompilerException(
                            string.Format(@"Port signal ""{0}"" of chip ""{1}"" does not have attribute ""pin_assignment""",
                                chipInputSignal.name, gateChip.chipName));


            // ゲートの余った入力
            if (gateChip.defaultHigh)
                    {
                        if (!design.signalTable.ContainsKey("VCC") || !(design.signalTable["VCC"] is StdLogic))
                            throw new CompilerException(
                            string.Format(@"Signal ""{0}"" was not found in design", "VCC"));

                        var vccSignal = (StdLogic)design.signalTable["VCC"];
                        netMap[vccSignal].adjacentNodes.Add(new Node(this, (int)chipInputSignal.attribute["pin_assign"]));
                    }
                    else
                    {
                        if (!design.signalTable.ContainsKey("GND") || !(design.signalTable["GND"] is StdLogic))
                            throw new CompilerException(
                            string.Format(@"Signal ""{0}"" was not found in design", "GND"));

                        var groundSignal = (StdLogic)design.signalTable["GND"];
                        netMap[groundSignal].adjacentNodes.Add(new Node(this, (int)chipInputSignal.attribute["pin_assign"]));
                    }
                }

                var netOutputSignal = netMap[(StdLogic)gates[i].outputSignal];
                var chipOutputSignal = gateChip.portNameMappings[i][new StdLogic(new SignalName(".out"))];
                if (!chipOutputSignal.attribute.ContainsKey("pin_assign"))
                    throw new CompilerException(
                        string.Format(@"Port signal ""{0}"" of chip ""{1}"" does not have attribute ""pin_assignment""",
                        chipOutputSignal.name, gateChip.chipName));

                netOutputSignal.adjacentNodes.Add(new Node(this, (int)chipOutputSignal.attribute["pin_assign"]));
            }

            ProcesConstAssign(this, design, representingNet);
        }

        // チップのconst_assignを処理
        void ProcesConstAssign(
            NetComponents libParts, 
            
            DeclaredObjectContainer design,
            Dictionary<StdLogic, Net> representingNet)
        {
            foreach (var constAssign in chip.constAssignMappings)
            {
                Net assignedNet;

                if (constAssign.Value.baseName.ToLower() == "open")
                {
                    var tempSignal = new StdLogic(design.signalNameGenerator.getSignalName());
                    assignedNet = representingNet[tempSignal] = new Net(".temp");
                }
                else
                {
                    var assignedSignalName = constAssign.Value;
                    if (!design.signalTable.ContainsKey(assignedSignalName.baseName))
                        throw new CompilerException(
                            string.Format(@"Signal ""{0}"", which is specified in component ""{1}"" is not defined in the design file", 
                            assignedSignalName.baseName, chip.chipName));

                    var assignedSignal = design.signalTable[assignedSignalName];
                    if (!(assignedSignal is StdLogic))
                        throw new CompilerException(
                            string.Format(@"Signal ""{0}"", which is specified in component ""{1}"" is not std_logic",
                            assignedSignalName.baseName, chip.chipName));

                    assignedNet = representingNet[(StdLogic)assignedSignal];
                }

                if (!constAssign.Key.attribute.ContainsKey("pin_assign"))
                    throw new CompilerException(
                        string.Format(@"Port signal ""{0}"" of chip ""{1}"" does not have attribute ""pin_assignment""",
                        constAssign.Key.name, chip.chipName));

                int portPin = (int)constAssign.Key.attribute["pin_assign"];
                assignedNet.adjacentNodes.Add(new Node(libParts, portPin));
            }
        }



    }
}
