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
    class ComponentDeclarationEvaluator : NodeEvaluator
    {
        public ComponentDeclarationEvaluator(DeclaredObjectContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            string entityName = node.ChildNodes[1].Token.Text;
            var portSignals = new SignalTable();

            var portClauseNode = node.ChildNodes[4].ChildNodes[0];
            foreach (var declarationNode in portClauseNode.ChildNodes[2].ChildNodes)
            {
                if (declarationNode.ChildNodes[0].Term.Name == "object_declaration")
                {
                    var signals = (List<ISignal>)EvaluateGeneral(declarationNode.ChildNodes[0]);
                    foreach (var signal in signals)
                        portSignals[signal.name] = signal;
                }
            }

            var entity = new ComponentPrototype(entityName, portSignals);
            this.declaredObjects.componentDeclarations[entityName] = entity;
            return entity;
        }
    }
}
