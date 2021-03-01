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
    }
}
