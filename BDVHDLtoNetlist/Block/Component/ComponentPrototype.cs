using BDVHDLtoNetlist.Block.Signal;
using BDVHDLtoNetlist.Parser.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Block.Component
{
    class ComponentPrototype
    {
        public string name { get; }
        public SignalTable signals { get; }

        public ComponentPrototype(string name, SignalTable signals)
        {
            this.name = name;
            this.signals = signals;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(ComponentPrototype))
                return false;
            else
            {
                var foreignSignals = ((ComponentPrototype)obj).signals;
                return this.name.ToLower() == ((ComponentPrototype)obj).name.ToLower() &&
                        this.signals.Count == foreignSignals.Count && 
                        !this.signals.Except(foreignSignals).Any();
            }
        }

        public override int GetHashCode()
        {
            return this.signals.Aggregate(this.name.ToLower().GetHashCode(), (y, x) => y ^ x.Key.GetHashCode() ^ x.Value.GetHashCode());
        }

    }
}
