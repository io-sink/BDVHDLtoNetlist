using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Parser.Utility
{
    class SignalTable : Dictionary<string, ISignal>
    {
        public SignalTable() : base(StringComparer.OrdinalIgnoreCase)
        { 
        }

        public ISignal this[SignalName signalName]
        {
            get
            {
                return this[signalName.baseName];
            }

            set
            {
                this[signalName.baseName] = value;
            }
        }
    }
}
