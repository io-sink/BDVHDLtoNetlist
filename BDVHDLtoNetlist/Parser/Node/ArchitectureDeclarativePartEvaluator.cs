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
    class ArchitectureDeclarativePartEvaluator : NodeEvaluator
    {
        public ArchitectureDeclarativePartEvaluator(DeclaredObjectContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            foreach (var childNode in node.ChildNodes)
                if(childNode.ChildNodes[0].Term.Name == "object_declaration")
                {
                    var signals = (List<ISignal>)EvaluateGeneral(childNode.ChildNodes[0]);

                    foreach (var signal in signals)
                        this.declaredObjects.signalTable[signal.name] = signal;
                }
                else
                {
                    EvaluateGeneral(childNode.ChildNodes[0]);
                }

            return null;
        }
    }
}
