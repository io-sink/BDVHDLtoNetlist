using BDVHDLtoNetlist.Parser.Utility;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Parser.Node
{
    class ComponentInstatiationStatementEvaluator : NodeEvaluator
    {
        public ComponentInstatiationStatementEvaluator(UtilityContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            string componentName = node.ChildNodes[0].Token.Text;

            var associationListNode = node.ChildNodes[5].ChildNodes[0].ChildNodes[0].ChildNodes[3];
            foreach(var associationElementNode in associationListNode.ChildNodes)
            {

            }

            return null;
        }
    }
}
