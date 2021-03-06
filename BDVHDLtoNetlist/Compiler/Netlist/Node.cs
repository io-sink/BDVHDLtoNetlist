using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Compiler.Netlist
{
    class Node
    {
        public NetComponents libParts { get; }
        public int pin { get; }

        public Node(NetComponents libParts, int pin)
        {
            this.libParts = libParts;
            this.pin = pin;
        }
    }
}
