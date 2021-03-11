using System;
using System.Collections.Generic;
using System.Text;
using BDVHDLtoNetlist.Block.Component;
using BDVHDLtoNetlist.Block.Gate;
using BDVHDLtoNetlist.Block.Signal;
using BDVHDLtoNetlist.Exceptions;
using BDVHDLtoNetlist.Parser;
using BDVHDLtoNetlist.Parser.Node;
using BDVHDLtoNetlist.Parser.Utility;
using Irony.Interpreter;
using Irony.Parsing;

namespace BDVHDLtoNetlist.Parser
{
    class MyParser
    {
        public DeclaredObjectContainer Parse(string programFile)
        {
            string program = System.IO.File.ReadAllText(programFile);

            var grammar = new BDVHDLGrammar();
            var parser = new Irony.Parsing.Parser(grammar);
            var ast = parser.Parse(program);

            if (ast.Status != ParseTreeStatus.Parsed)
                throw new ParserException(programFile, ast.Status, ast.ParserMessages);

            (new TreeConverter()).Convert(ast, grammar);

            var evaluator = new NodeEvaluator();
            evaluator.EvaluateGeneral(ast.Root);

            return evaluator.declaredObjects;
        }

    }
}
