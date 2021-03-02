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
    class NameEvaluator : NodeEvaluator
    {
        public NameEvaluator(UtilityContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            string baseName = node.ChildNodes[0].ChildNodes[0].Token.Text;

            if(node.ChildNodes[0].Term.Name == "indexed_name")
            {
                int index = (int)node.ChildNodes[0].ChildNodes[2].Token.Value;

                return new SignalName(baseName, index);
            }
            else if (node.ChildNodes[0].Term.Name == "slice_name")
            {
                var range = (Tuple<int, int>)EvaluateGeneral(node.ChildNodes[0].ChildNodes[2]);
                return new SignalName(baseName, range.Item1, range.Item2);
            }
            else if (node.ChildNodes[0].Term.Name == "simple_name")
            {
                return new SignalName(baseName);
            }

            return null;
        }
    }
}
