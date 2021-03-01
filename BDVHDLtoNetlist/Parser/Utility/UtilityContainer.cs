using BDVHDLtoNetlist.Block.Component;
using BDVHDLtoNetlist.Block.Gate;
using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Parser.Utility
{
    class UtilityContainer
    {
        public SignalTable signalTable;
        public Dictionary<string, ComponentPrototype> componentDeclarations;

        public List<Tuple<ISignal, ISignal>> assignments;
        public List<LogicGate> logicGates;
        public List<Component> components;

        public SignalNameGenerator signalNameGenerator;

        public UtilityContainer()
        {
            this.signalTable = new SignalTable();
            this.componentDeclarations = new Dictionary<string, ComponentPrototype>(StringComparer.OrdinalIgnoreCase);
            this.assignments = new List<Tuple<ISignal, ISignal>>();
            this.logicGates = new List<LogicGate>();
            this.components = new List<Component>();
            this.signalNameGenerator = new SignalNameGenerator();
        }
    }
}
