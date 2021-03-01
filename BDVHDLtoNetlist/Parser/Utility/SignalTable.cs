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

        public ISignal ResolveSignal(SignalName signalName)
        {
            if(!this.ContainsKey(signalName.baseName))
            {
                Console.Error.WriteLine("invalid signal: " + signalName.baseName);
                return new StdLogic(signalName);
            }

            if(this[signalName] is StdLogic)
                return new StdLogic(new SignalName(signalName.baseName));
            else if(this[signalName] is StdLogicVector)
            {
                if (signalName.edIndex == null)
                    return new StdLogic(new SignalName(signalName.baseName));
                else
                    return new StdLogicVector(new SignalName(signalName.baseName), (int)signalName.stIndex, (int)signalName.edIndex);
            }

            return null;
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
