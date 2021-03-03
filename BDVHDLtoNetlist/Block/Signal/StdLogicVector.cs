using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Block.Signal
{
    class StdLogicVector : ISignal
    {
        public SignalMode mode { get; }
        public SignalName name { get; }

        public int stRange { get; }
        public int size { get; }

        public Dictionary<string, object> attribute { get; }

        private StdLogic[] logic;

        public StdLogic GetLogic(int index) { return logic[index - stRange]; }

        public StdLogicVector(SignalName name, int stRange, int edRange, SignalMode mode = SignalMode.NONE)
        {
            this.mode = mode;
            this.name = name;
            this.stRange = stRange;
            this.size = edRange - stRange + 1;

            logic = new StdLogic[this.size];
            for (int i = stRange; i <= edRange; ++i)
                logic[i - stRange] = new StdLogic(new SignalName(name.baseName, i), mode);

            this.attribute = new Dictionary<string, object>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
                return this.name.Equals(((StdLogicVector)obj).name) &&
                    this.stRange == ((StdLogicVector)obj).stRange &&
                    this.size == ((StdLogicVector)obj).size;
        }

        public bool Assignable(ISignal other)
        {
            return this.GetType() == other.GetType() && 
                this.size == ((StdLogicVector)other).size;
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() ^ this.stRange.GetHashCode() ^ this.size.GetHashCode();
        }

        public override string ToString()
        {
            string res = string.Format("{0}: std_logic_vector[{1}..{2}]({3}, ", name, stRange, size, mode);
            foreach (var pair in this.attribute)
                res += string.Format("{0} = {1}, ", pair.Key, pair.Value);
            res += ")";
            return res;
        }
    }
}
