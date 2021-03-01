using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Parser.Utility
{
    class SignalNameGenerator
    {
        private int signalCount = 0;
        public SignalName getSignalName()
        {
            return new SignalName(".tmp_signal" + ++signalCount);
        }
    }

}
