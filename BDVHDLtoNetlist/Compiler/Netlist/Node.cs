using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Compiler.Netlist
{
    class Node
    {
        public LibParts libParts { get; }
        public int pin { get; }

        public Node(LibParts libParts, int pin)
        {
            this.libParts = libParts;
            this.pin = pin;
        }
    }
}
