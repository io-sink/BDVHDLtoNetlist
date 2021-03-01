using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Block.Signal
{
    class StdLogic : ISignal
    {
        public SignalMode mode { get; }

        public SignalName name { get; }

        public StdLogic(SignalName name, SignalMode mode = SignalMode.NONE)
        {
            this.mode = mode;
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(StdLogic))
                return false;
            else
                return this.name.Equals(((StdLogic)obj).name);
        }

        public bool Assignable(ISignal other)
        {
            return this.GetType() == other.GetType();
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}: std_logic ({1})", name, mode);
        }

    }
}
