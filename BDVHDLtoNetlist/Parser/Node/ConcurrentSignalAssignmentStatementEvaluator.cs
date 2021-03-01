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
    class ConcurrentSignalAssignmentStatementEvaluator : NodeEvaluator
    {
        public ConcurrentSignalAssignmentStatementEvaluator(UtilityContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            var leftHandSide = this.utility.signalTable.ResolveSignal(
                (SignalName)EvaluateGeneral(node.ChildNodes[0]));

            var rightHandSide = (ISignal)EvaluateGeneral(node.ChildNodes[2]);

            this.utility.assignments.Add(new Tuple<ISignal, ISignal>(leftHandSide, rightHandSide));
            return null;
        }
    }
}
