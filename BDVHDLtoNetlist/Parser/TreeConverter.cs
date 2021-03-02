using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Parser
{
    class TreeConverter
    {
        /*
            - 先頭が"Unnamed"のノードを削除
            - ?の文法から生成されるターム名は"?"に統一
         */ 


        public void Convert(ParseTree tree, Grammar grammar)
        {
            TreeDFS(tree.Root);
        }

        private void TreeDFS(ParseTreeNode node)
        {
            var replacedNodes = new Dictionary<int, ParseTreeNode>();

            for(int i = 0; i < node.ChildNodes.Count; ++i)
                if (node.ChildNodes[i].Term.Name.StartsWith("Unnamed"))
                    replacedNodes[i] = node.ChildNodes[i];

            foreach (int index in replacedNodes.Keys)
            {
                node.ChildNodes.RemoveAt(index);
                node.ChildNodes.InsertRange(index, replacedNodes[index].ChildNodes);
            }

            if (node.Term.Name.Last() == '?')
                node.Term.Name = "?";

            foreach (var child in node.ChildNodes)
                TreeDFS(child);
        }

    }
}
