using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDVHDLtoNetlist.Block;

namespace BDVHDLtoNetlist.Compiler.Netlist
{
    class Net
    {
        private static int count = 0;

        public string name { get; }

        public List<Node> adjacentNodes { get; }

        public Net(List<Node> adjacentNodes = null)
        {
            this.name = string.Format("Net-{0}", ++count);
            this.adjacentNodes = adjacentNodes == null ? new List<Node>() : adjacentNodes;
        }
    }
}
