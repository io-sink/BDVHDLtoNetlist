using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Block.Gate
{
    class LogicGate
    {
        public enum GateType
        {
            NOT, AND, OR, XOR, NAND, NOR, XNOR
        }

        private static int gateCount = 0;

        public string name { get; }
        public GateType gateType { get; set; }

        public List<ISignal> inputSignals { get; }
        public ISignal outputSignal { get; }

        public LogicGate(GateType gateType, List<ISignal> inputSignals, ISignal outputSignal)
        {
            this.name = ".logicGate" + ++gateCount;
            this.gateType = gateType;
            this.inputSignals = inputSignals;
            this.outputSignal = outputSignal;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
                return this.name == ((LogicGate)obj).name;
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }

    }
}
