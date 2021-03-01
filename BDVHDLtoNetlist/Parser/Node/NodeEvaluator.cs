using BDVHDLtoNetlist.Block.Component;
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
    class NodeEvaluator
    {
        public UtilityContainer utility;
        private static Dictionary<string, Type> evaluatorTypes = new Dictionary<string, Type>()
        {
            { "entity_declaration", typeof(EntityDeclarationEvaluator) },

            { "architecture_declarative_part", typeof(ArchitectureDeclarativePartEvaluator) },
            { "component_declaration", typeof(ComponentDeclarationEvaluator) },
            { "object_declaration", typeof(ObjectDeclarationEvaluator) },
            { "identifier_list", typeof(IdentifierListEvaluator) },
            { "range_constraint", typeof(RangeConstraintEvaluator) },
            

            { "concurrent_signal_assignment_statement", typeof(ConcurrentSignalAssignmentStatementEvaluator) },
            { "expression", typeof(ExpressionEvaluator) },
            { "factor", typeof(FactorEvaluator) },
            { "primary", typeof(PrimaryEvaluator) },
            { "name", typeof(NameEvaluator) },

            { "component_instantiation_statement", typeof(ComponentInstatiationStatementEvaluator) },
        };

        public NodeEvaluator(UtilityContainer utility = null)
        {
            this.utility = utility == null ? new UtilityContainer() : utility;
        }

        public virtual object Evaluate(ParseTreeNode node)
        {
            foreach (var childNode in node.ChildNodes)
                EvaluateGeneral(childNode);
            return null;
        }

        public object EvaluateGeneral(ParseTreeNode node)
        {
            if (evaluatorTypes.ContainsKey(node.Term.Name))
            {
                var selectedEvaluator = (NodeEvaluator)Activator.CreateInstance(evaluatorTypes[node.Term.Name], this.utility);
                return selectedEvaluator.Evaluate(node);
            }
            else
                return this.Evaluate(node);
        }

    }
}
