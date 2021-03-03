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
    class ObjectDeclarationEvaluator : NodeEvaluator
    {
        public ObjectDeclarationEvaluator(DeclaredObjectContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            var signals = new List<ISignal>();
            SignalMode signalMode = SignalMode.NONE;
            var signalNames = new List<string>();

            foreach (var childNode in node.ChildNodes)
            {
                if (childNode.ChildNodes.Count > 0 && childNode.ChildNodes[0].Term.Name == "object_type")
                {
                    string signalType = childNode.ChildNodes[0].ChildNodes[0].Token.Text.ToLower();

                    if (signalType != "signal")
                        return signals;
                }
                else if (childNode.Term.Name == "identifier_list")
                {
                    foreach (var gchildNode in childNode.ChildNodes)
                        if (gchildNode.Term.Name == "identifier")
                            signalNames.Add(gchildNode.Token.Text);
                }
                else if (childNode.ChildNodes.Count > 0 && childNode.ChildNodes[0].Term.Name == "object_mode")
                {
                    signalMode = (SignalMode)Enum.Parse(typeof(SignalMode), childNode.ChildNodes[0].ChildNodes[0].Token.Text, true);
                }
                else if (childNode.Term.Name == "subtype_indication")
                {

                    if (childNode.ChildNodes[0].Token.Text.ToLower() == "std_logic")
                    {
                        signals.AddRange(signalNames.Select(x =>
                            new StdLogic(new SignalName(x), signalMode)));
                    }
                    else if (childNode.ChildNodes[0].Token.Text.ToLower() == "std_logic_vector")
                    {
                        var range = (Tuple<int, int>)EvaluateGeneral(childNode.ChildNodes[1].ChildNodes[1]);

                        signals.AddRange(signalNames.Select(x =>
                                new StdLogicVector(new SignalName(x), range.Item1, range.Item2, signalMode)));
                    }

                }
            }

            return signals;
        }
    }
}
