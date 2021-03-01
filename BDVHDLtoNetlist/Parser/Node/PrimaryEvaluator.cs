using BDVHDLtoNetlist.Block.Gate;
using BDVHDLtoNetlist.Block.Signal;
using BDVHDLtoNetlist.Parser.Utility;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Parser.Node
{
    class PrimaryEvaluator : NodeEvaluator
    {
        public PrimaryEvaluator(UtilityContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            if(node.ChildNodes.Count == 1)
                return this.utility.signalTable.ResolveSignal((SignalName)EvaluateGeneral(node.ChildNodes[0]));
            else
                return EvaluateGeneral(node.ChildNodes[1]);
        }
    }
}
