using BDVHDLtoNetlist.Parser.Utility;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Parser.Node
{
    class RangeConstraintEvaluator : NodeEvaluator
    {
        public RangeConstraintEvaluator(DeclaredObjectContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            int rangeNum1 = (int)node.ChildNodes[0].Token.Value;
            int rangeNum2 = (int)node.ChildNodes[2].Token.Value;

            if (node.ChildNodes[1].ChildNodes[0].Token.Text.ToLower() == "to")
                return new Tuple<int, int>(rangeNum1, rangeNum2);
            else if (node.ChildNodes[1].ChildNodes[0].Token.Text.ToLower() == "downto")
                return new Tuple<int, int>(rangeNum2, rangeNum1);
            return null;
        }
    }
}
