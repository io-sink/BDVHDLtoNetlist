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

            if (this[signalName] is StdLogic)
            {
                return this[signalName];
            }
            else if (this[signalName] is StdLogicVector)
            {
                if (signalName.stIndex == null && signalName.edIndex == null)
                    return this[signalName];
                else if (signalName.edIndex == null)
                    return ((StdLogicVector)this[signalName]).GetLogic((int)signalName.stIndex);
                else
                    return new StdLogicVector(new SignalName(signalName.baseName),
                        (int)signalName.stIndex, (int)signalName.edIndex, this[signalName].mode);
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
