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
    class EntityDeclarationEvaluator : NodeEvaluator
    {
        public EntityDeclarationEvaluator(DeclaredObjectContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            string entityName = node.ChildNodes[1].Token.Text;
            var portSignals = new SignalTable();
            this.declaredObjects.entityPrototype = new ComponentPrototype(entityName, portSignals);

            var portClauseNode = node.ChildNodes[3].ChildNodes[1].ChildNodes[0];

            foreach (var declarationNode in portClauseNode.ChildNodes[2].ChildNodes)
                if (declarationNode.ChildNodes[0].Term.Name == "object_declaration")
                {
                    var signals = (List<ISignal>)EvaluateGeneral(declarationNode.ChildNodes[0]);
                    foreach (var signal in signals)
                    {
                        portSignals[signal.name] = signal;
                        this.declaredObjects.signalTable[signal.name] = signal;
                    }
                }
                else if (declarationNode.ChildNodes[0].Term.Name == "attribute_specification")
                {
                    var attribute = EvaluateGeneral(declarationNode.ChildNodes[0]);
                    if (attribute != null)
                    {
                        var pair = (KeyValuePair<Tuple<string, string>, object>)attribute;

                        if(pair.Key.Item1 == this.declaredObjects.entityPrototype.name)
                            this.declaredObjects.entityAttribute[pair.Key.Item2] = pair.Value;
                        else if(portSignals.ContainsKey(pair.Key.Item1))
                        portSignals[pair.Key.Item1].attribute[pair.Key.Item2] = pair.Value;
                    }
                }

            this.declaredObjects.componentDeclarations[entityName] = this.declaredObjects.entityPrototype;
            return null;
        }
    }
}
