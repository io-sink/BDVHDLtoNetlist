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
        public ConcurrentSignalAssignmentStatementEvaluator(DeclaredObjectContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            var leftHandSide = this.declaredObjects.signalTable.ResolveSignal(
                (SignalName)EvaluateGeneral(node.ChildNodes[0]));

            var expression = EvaluateGeneral(node.ChildNodes[2]);
            if (!(expression is ISignal))
                throw new Exception("unsupported operation");

            var rightHandSide = (ISignal)expression;

            this.declaredObjects.assignments.Add(new KeyValuePair<ISignal, ISignal>(leftHandSide, rightHandSide));
            return null;
        }
    }
}
