using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Writer
{
    class SExpr
    {
        public string symbol { get; }

        public bool isTerminal { get; }

        public LinkedList<SExpr> children { get; }

        public string terminalValue { get; }

        public SExpr(string symbol, LinkedList<SExpr> children = null)
        {
            this.symbol = symbol;
            this.isTerminal = false;
            this.children = children == null ? new LinkedList<SExpr>() : children;
        }

        public SExpr(string symbol, string terminalValue)
        {
            this.symbol = symbol;
            this.isTerminal = true;
            this.terminalValue = terminalValue;
        }

        public override string ToString()
        {
            return ToString(0);
        }

        public string ToString(int depth)
        {
            if(isTerminal)
                return string.Format("{0}({1} {2})", new string(' ', depth * 2), this.symbol, this.terminalValue);
            else
                return string.Format("{0}({1} \n{2})", new string(' ', depth * 2), this.symbol,
                    string.Join("\n", this.children.Select(c => c.ToString(depth + 1))));
        }
    }
}
