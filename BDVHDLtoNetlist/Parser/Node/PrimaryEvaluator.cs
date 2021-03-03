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
        public PrimaryEvaluator(DeclaredObjectContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            if (node.ChildNodes.Count > 1)
                return EvaluateGeneral(node.ChildNodes[1]);
            else if (node.ChildNodes[0].Term.Name == "string")
                return node.ChildNodes[0].Token.Value;
            else if (node.ChildNodes[0].Term.Name == "number")
                return node.ChildNodes[0].Token.Value;
            else
                return this.declaredObjects.signalTable.ResolveSignal((SignalName)EvaluateGeneral(node.ChildNodes[0]));

        }
    }
}
