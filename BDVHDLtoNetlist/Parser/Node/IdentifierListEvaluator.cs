using BDVHDLtoNetlist.Parser.Utility;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Parser.Node
{
    class IdentifierListEvaluator : NodeEvaluator
    {
        public IdentifierListEvaluator(UtilityContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            var result = new List<string>();
            foreach (var childNode in node.ChildNodes)
                if (childNode.Term.Name == "identifier")
                    result.Add(childNode.Token.Text);
            return result;
        }
    }
}
