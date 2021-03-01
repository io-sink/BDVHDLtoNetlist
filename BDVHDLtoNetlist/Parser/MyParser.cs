using System;
using System.Collections.Generic;
using System.Text;
using BDVHDLtoNetlist.Block.Component;
using BDVHDLtoNetlist.Block.Gate;
using BDVHDLtoNetlist.Block.Signal;
using BDVHDLtoNetlist.Parser;
using BDVHDLtoNetlist.Parser.Node;
using Irony.Interpreter;
using Irony.Parsing;

namespace BDVHDLtoNetlist.Parser
{
    class MyParser
    {

        public bool Parse(string program)
        {
            var parser = new Irony.Parsing.Parser(new BDVHDLGrammar());
            var ast = parser.Parse(program);


            Console.WriteLine(ast.Status);
            foreach (var msg in ast.ParserMessages)
                Console.WriteLine("{0}: {1}", msg.Location, msg.Message);

            if (ast.Status != ParseTreeStatus.Parsed)
                return false;

            var evaluator = new NodeEvaluator();
            evaluator.EvaluateGeneral(ast.Root);


            foreach (string signalName in evaluator.utility.signalTable.Keys)
                Console.WriteLine("[SIGNAL] ({0}) -> ({1})", signalName, evaluator.utility.signalTable[signalName]);

            foreach (var tuple in evaluator.utility.assignments)
                Console.WriteLine("[ASSIGN] ({0}) <- ({1})", tuple.Item1, tuple.Item2);

            foreach(var gate in evaluator.utility.logicGates)
            {
                Console.Write("[GATE] ({0}) <- ({1}) ", gate.outputSignal, gate.gateType);
                foreach (var inputSignal in gate.inputSignals)
                    Console.Write("({0}), ", inputSignal);
                Console.WriteLine();
            }

            foreach(var componentPrototype in evaluator.utility.componentDeclarations)
            {
                Console.WriteLine("[COMPONENT_DECLR] {0}:", componentPrototype.Key);
                foreach(var signal in componentPrototype.Value.signals)
                    Console.WriteLine("\t{0}", signal);
            }

            foreach (var component in evaluator.utility.components)
            {
                Console.WriteLine("[COMPONENT] {0}: {1}", component.name, component.prototype.name);
                foreach (var signal in component.portMap.Keys)
                    Console.WriteLine("\t{0} -> {1}", signal, component.portMap[signal]);
            }

            return true;
        }


    }
}
