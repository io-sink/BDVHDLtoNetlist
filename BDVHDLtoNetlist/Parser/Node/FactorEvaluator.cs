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
    class FactorEvaluator : NodeEvaluator
    {
        public FactorEvaluator(UtilityContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            if (node.ChildNodes[0].Term.Name == "not")
            {
                var newSignalName = this.utility.signalNameGenerator.getSignalName();
                var newSignal = new StdLogic(newSignalName);

                var inputSignal = (ISignal)EvaluateGeneral(node.ChildNodes[1]);

                var notGate = new LogicGate(LogicGate.GateType.NOT, new List<ISignal> { inputSignal }, newSignal);
                this.utility.logicGates.Add(notGate);

                return newSignal;
            }
            else
            {
                return EvaluateGeneral(node.ChildNodes[0]);
            }

        }
    }
}
