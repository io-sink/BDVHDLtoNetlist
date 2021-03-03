using BDVHDLtoNetlist.Parser.Utility;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Parser.Node
{
    class AttributeSpecificationEvaluator : NodeEvaluator
    {
        public AttributeSpecificationEvaluator(DeclaredObjectContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            string attributeName = node.ChildNodes[1].Token.Text;
            string targetName = node.ChildNodes[3].Token.Text;

            var expression = EvaluateGeneral(node.ChildNodes[5]);
            return new KeyValuePair<Tuple<string, string>, object>(
                new Tuple<string, string>(targetName, attributeName), expression);
        }
    }
}
