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

        public int id { get; }
        public string name { get { return string.Format("Net-{0}", this.id); } }

        public string signalName { get; }

        public List<Node> adjacentNodes { get; }

        public Net(string signalName, List<Node> adjacentNodes = null)
        {
            this.id = ++count;
            this.signalName = signalName;
            this.adjacentNodes = adjacentNodes == null ? new List<Node>() : adjacentNodes;
        }
    }
}
