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
        public ExpressionEvaluator(DeclaredObjectContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            if (node.ChildNodes[0].ChildNodes.Count == 1)
            {
                return EvaluateGeneral(node.ChildNodes[0].ChildNodes[0]);
            }
            else
            {
                var inputSignals = new List<ISignal>();
                foreach (var factorNode in node.ChildNodes[0].ChildNodes)
                {
                    var factor = EvaluateGeneral(factorNode);
                    if (!(factor is ISignal))
                        throw new Exception("unsupported operation");

                    inputSignals.Add((ISignal)factor);
                }

                var gateType = (LogicGate.GateType)Enum.Parse(typeof(LogicGate.GateType),
                    node.ChildNodes[0].Term.Name.Split('_')[0], true);

                var newSignalName = this.declaredObjects.signalNameGenerator.getSignalName();
                var newSignal = new StdLogic(newSignalName);
                this.declaredObjects.signalTable[newSignalName] = newSignal;

                var logicGate = new LogicGate(gateType, inputSignals, newSignal);
                this.declaredObjects.logicGates.Add(logicGate);

                return newSignal;
            }

        }
    }
}
