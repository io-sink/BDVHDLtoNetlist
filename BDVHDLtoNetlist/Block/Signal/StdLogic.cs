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

        public Dictionary<string, object> attribute { get; }

        public StdLogic(SignalName name, SignalMode mode = SignalMode.NONE)
        {
            this.mode = mode;
            this.name = name;
            this.attribute = new Dictionary<string, object>();
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
            string res = string.Format("{0}: std_logic({1}, ", name, mode);
            foreach (var pair in this.attribute)
                res += string.Format("{0} = {1}, ", pair.Key, pair.Value);
            res += ")";
            return res;
        }

    }
}
