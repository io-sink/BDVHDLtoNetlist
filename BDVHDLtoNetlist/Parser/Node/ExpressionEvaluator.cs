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
    class ExpressionEvaluator : NodeEvaluator
    {
        public ExpressionEvaluator(UtilityContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            if (node.ChildNodes[0].ChildNodes.Count == 1)
            {
                return EvaluateGeneral(node.ChildNodes[0].ChildNodes[0]);
            }
            else if (node.ChildNodes[0].Term.Name == "and_expression")
            {
                var gateType = (LogicGate.GateType)Enum.Parse(typeof(LogicGate.GateType), 
                    node.ChildNodes[0].Term.Name.Split('_')[0], true);

                var newSignalName = this.utility.signalNameGenerator.getSignalName();
                var newSignal = new StdLogic(newSignalName);

                var inputSignals = new List<ISignal>();
                foreach (var factorNode in node.ChildNodes[0].ChildNodes)
                    inputSignals.Add((ISignal)EvaluateGeneral(factorNode));

                var logicGate = new LogicGate(gateType, inputSignals, newSignal);
                this.utility.logicGates.Add(logicGate);

                return newSignal;
            }

            return null;
        }
    }
}
