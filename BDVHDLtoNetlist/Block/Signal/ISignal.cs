using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Block.Signal
{
    interface ISignal
    {
        SignalMode mode { get; }

        SignalName name { get; }
        
        bool Assignable(ISignal other);
    }

    public enum SignalMode
    {
        NONE = 0, IN = 1, OUT = 2, INOUT = 3
    }
}
