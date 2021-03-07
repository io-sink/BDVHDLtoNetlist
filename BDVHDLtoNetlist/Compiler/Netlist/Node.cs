using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Compiler.Netlist
{
    class Node
    {
        public NetComponents netComponent { get; }
        public int pin { get; }

        public Node(NetComponents libParts, int pin)
        {
            this.netComponent = libParts;
            this.pin = pin;
        }
    }
}
