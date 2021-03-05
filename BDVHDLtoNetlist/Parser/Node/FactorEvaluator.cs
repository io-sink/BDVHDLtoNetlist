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
        public FactorEvaluator(DeclaredObjectContainer utility) : base(utility)
        {
        }

        public override object Evaluate(ParseTreeNode node)
        {
            if (node.ChildNodes[0].Term.Name == "not")
            {
                var primary = EvaluateGeneral(node.ChildNodes[1]);
                if (!(primary is ISignal))
                    throw new Exception("unsupported operation");

                var inputSignal = (ISignal)primary;

                if(!inputSignal.name.isTemp)
                {
                    // notゲートを生成
                    var newSignalName = this.declaredObjects.signalNameGenerator.getSignalName();
                    var newSignal = new StdLogic(newSignalName);
                    this.declaredObjects.signalTable[newSignalName] = newSignal;

                    var notGate = new LogicGate(LogicGate.GateType.NOT, new List<ISignal> { inputSignal }, newSignal);
                    this.declaredObjects.logicGates.Add(notGate);

                    return newSignal;
                }
                else
                {
                    // and, or, xorをnand, nor, xnorに変換
                    foreach(var gate in this.declaredObjects.logicGates)
                        if(gate.outputSignal.Equals(inputSignal))
                        {
                            switch (gate.gateType) 
                            {
                                case LogicGate.GateType.AND:
                                    gate.gateType = LogicGate.GateType.NAND;
                                    break;
                                case LogicGate.GateType.OR:
                                    gate.gateType = LogicGate.GateType.NOR;
                                    break;
                                case LogicGate.GateType.XOR:
                                    gate.gateType = LogicGate.GateType.XNOR;
                                    break;
                                default:
                                    throw new Exception("");
                            }
                            return inputSignal;
                        }

                    throw new Exception("");
                }

            }
            else
            {
                return EvaluateGeneral(node.ChildNodes[0]);
            }

        }
    }
}
