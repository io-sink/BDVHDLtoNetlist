using BDVHDLtoNetlist.Block.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Parser.Utility
{
    class TempSignalNameGenerator
    {
        private int signalCount = 0;
        public SignalName getSignalName()
        {
            var tempSignal = new SignalName(".tmp_signal" + ++signalCount);
            tempSignal.SetTemp();

            return tempSignal;
        }
    }

}
