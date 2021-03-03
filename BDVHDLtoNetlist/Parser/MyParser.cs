using System;
using System.Collections.Generic;
using System.Text;
using BDVHDLtoNetlist.Block.Component;
using BDVHDLtoNetlist.Block.Gate;
using BDVHDLtoNetlist.Block.Signal;
using BDVHDLtoNetlist.Parser;
using BDVHDLtoNetlist.Parser.Node;
using BDVHDLtoNetlist.Parser.Utility;
using Irony.Interpreter;
using Irony.Parsing;

namespace BDVHDLtoNetlist.Parser
{
    class MyParser
    {
        public DeclaredObjectContainer Parse(string program)
        {
            var grammar = new BDVHDLGrammar();
            var parser = new Irony.Parsing.Parser(grammar);
            var ast = parser.Parse(program);

            Console.WriteLine(ast.Status);
            foreach (var msg in ast.ParserMessages)
                Console.WriteLine("{0}: {1}", msg.Location, msg.Message);

            if (ast.Status != ParseTreeStatus.Parsed)
                return null;

            (new TreeConverter()).Convert(ast, grammar);

            var evaluator = new NodeEvaluator();
            evaluator.EvaluateGeneral(ast.Root);

            return evaluator.declaredObjects;
        }

    }
}
