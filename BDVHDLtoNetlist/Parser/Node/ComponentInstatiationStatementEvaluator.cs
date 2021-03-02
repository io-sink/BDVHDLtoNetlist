using BDVHDLtoNetlist.Block.Component;
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
    class ComponentInstatiationStatementEvaluator : NodeEvaluator
    {
        public ComponentInstatiationStatementEvaluator(UtilityContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            string componentName = node.ChildNodes[0].Token.Text;
            string componentPrototypeName = node.ChildNodes[3].Token.Text;

            if (!this.utility.componentDeclarations.ContainsKey(componentPrototypeName))
                throw new Exception("Invalid component: " + componentPrototypeName);

            var componentPrototype = this.utility.componentDeclarations[componentPrototypeName];
            var portMap = new Dictionary<ISignal, ISignal>();

            var associationListNode = node.ChildNodes[5].ChildNodes[0].ChildNodes[3];
            foreach(var associationElementNode in associationListNode.ChildNodes)
            {
                var leftHandSide = componentPrototype.signals.ResolveSignal(
                    (SignalName)EvaluateGeneral(associationElementNode.ChildNodes[0]));
                var rightHandSide = this.utility.signalTable.ResolveSignal(
                    (SignalName)EvaluateGeneral(associationElementNode.ChildNodes[2]));

                portMap[leftHandSide] = rightHandSide;
            }

            var component = new Component(componentName, componentPrototype, portMap);
            this.utility.components.Add(component);

            return null;
        }
    }
}
