using System;
using System.Collections.Generic;
using System.Text;
using Irony.Interpreter;
using Irony.Parsing;

namespace BDVHDLtoNetlist.Parser
{
    [Language("BDVHDL")]
    class BDVHDLGrammar : Grammar
    {
        public BDVHDLGrammar() : base(false)
        {
            KeyTerm sComma = ToTerm(",");
            KeyTerm sPeriod = ToTerm(".");
            KeyTerm sColon = ToTerm(":");
            KeyTerm sSemicolon = ToTerm(";");
            KeyTerm sLParen = ToTerm("(");
            KeyTerm sRParen = ToTerm(")");
            KeyTerm sAssign = ToTerm("<=");
            KeyTerm sSeqAssign = ToTerm(":=");
            KeyTerm sRArrow = ToTerm("=>");

            KeyTerm sAbs = ToTerm("abs");
            KeyTerm sAccess = ToTerm("access");
            KeyTerm sAfter = ToTerm("after");
            KeyTerm sAlias = ToTerm("alias");
            KeyTerm sAll = ToTerm("all");
            KeyTerm sAnd = ToTerm("and");
            KeyTerm sArchitecture = ToTerm("architecture");
            KeyTerm sArray = ToTerm("array");
            KeyTerm sAssert = ToTerm("assert");
            KeyTerm sAttribute = ToTerm("attribute");
            KeyTerm sBegin = ToTerm("begin");
            KeyTerm sBlock = ToTerm("block");
            KeyTerm sBody = ToTerm("body");
            KeyTerm sBuffer = ToTerm("buffer");
            KeyTerm sBus = ToTerm("bus");
            KeyTerm sCase = ToTerm("case");
            KeyTerm sComponent = ToTerm("component");
            KeyTerm sConfiguration = ToTerm("configuration");
            KeyTerm sConstant = ToTerm("constant");
            KeyTerm sDisconnect = ToTerm("disconnect");
            KeyTerm sDownto = ToTerm("downto");
            KeyTerm sElse = ToTerm("else");
            KeyTerm sElsif = ToTerm("elsif");
            KeyTerm sEnd = ToTerm("end");
            KeyTerm sEntity = ToTerm("entity");
            KeyTerm sExit = ToTerm("exit");
            KeyTerm sFile = ToTerm("file");
            KeyTerm sFor = ToTerm("for");
            KeyTerm sFunction = ToTerm("function");
            KeyTerm sGenerate = ToTerm("generate");
            KeyTerm sGeneric = ToTerm("generic");
            KeyTerm sGroup = ToTerm("group");
            KeyTerm sGuarded = ToTerm("guarded");
            KeyTerm sIf = ToTerm("if");
            KeyTerm sImpure = ToTerm("impure");
            KeyTerm sIn = ToTerm("in");
            KeyTerm sInitial = ToTerm("inertial");
            KeyTerm sInout = ToTerm("inout");
            KeyTerm sIs = ToTerm("is");
            KeyTerm sLabel = ToTerm("label");
            KeyTerm sLibrary = ToTerm("library");
            KeyTerm sLinkage = ToTerm("linkage");
            KeyTerm sLiteral = ToTerm("literal");
            KeyTerm sLoop = ToTerm("loop");
            KeyTerm sMap = ToTerm("map");
            KeyTerm sMod = ToTerm("mod");
            KeyTerm sNand = ToTerm("nand");
            KeyTerm sNew = ToTerm("new");
            KeyTerm sNext = ToTerm("next");
            KeyTerm sNor = ToTerm("nor");
            KeyTerm sNot = ToTerm("not");
            KeyTerm sNull = ToTerm("null");
            KeyTerm sOf = ToTerm("of");
            KeyTerm sOn = ToTerm("on");
            KeyTerm sOpen = ToTerm("open");
            KeyTerm sOr = ToTerm("or");
            KeyTerm sOther = ToTerm("others");
            KeyTerm sOut = ToTerm("out");
            KeyTerm sPackage = ToTerm("package");
            KeyTerm sPort = ToTerm("port");
            KeyTerm sPostponed = ToTerm("postponed");
            KeyTerm sProcedure = ToTerm("procedure");
            KeyTerm sProcess = ToTerm("process");
            KeyTerm sPure = ToTerm("pure");
            KeyTerm sRange = ToTerm("range");
            KeyTerm sRecord = ToTerm("record");
            KeyTerm sRegister = ToTerm("register");
            KeyTerm sReject = ToTerm("reject");
            KeyTerm sReturn = ToTerm("return");
            KeyTerm sRol = ToTerm("rol");
            KeyTerm sRor = ToTerm("ror");
            KeyTerm sSelect = ToTerm("select");
            KeyTerm sSeverity = ToTerm("severity");
            KeyTerm sSignal = ToTerm("signal");
            KeyTerm sShared = ToTerm("shared");
            KeyTerm sSla = ToTerm("sla");
            KeyTerm sSli = ToTerm("sli");
            KeyTerm sSra = ToTerm("sra");
            KeyTerm sSrl = ToTerm("srl");
            KeyTerm sSubtype = ToTerm("subtype");
            KeyTerm sThen = ToTerm("then");
            KeyTerm sTo = ToTerm("to");
            KeyTerm sTransport = ToTerm("transport");
            KeyTerm sType = ToTerm("type");
            KeyTerm sUnaffected = ToTerm("unaffected");
            KeyTerm sUnits = ToTerm("units");
            KeyTerm sUntil = ToTerm("until");
            KeyTerm sUse = ToTerm("use");
            KeyTerm sVariable = ToTerm("variable");
            KeyTerm sWait = ToTerm("wait");
            KeyTerm sWhen = ToTerm("when");
            KeyTerm sWhile = ToTerm("while");
            KeyTerm sWidth = ToTerm("with");
            KeyTerm sXnor = ToTerm("xnor");
            KeyTerm sXor = ToTerm("xor");

            var comment = new CommentTerminal("comment", "--", "\n", "\r\n");
            NonGrammarTerminals.Add(comment);

            NumberLiteral sNumber = new NumberLiteral("number");
            IdentifierTerminal sIdentifier = new IdentifierTerminal("identifier", "\\_", "\\_0123456789");

            NonTerminal designFile = new NonTerminal("design_file");
            NonTerminal designUnit = new NonTerminal("design_unit");

            NonTerminal contextClause = new NonTerminal("context_clause");
            NonTerminal contextItem = new NonTerminal("context_item");
            NonTerminal libraryClause = new NonTerminal("library_clause");
            NonTerminal libraryNames = new NonTerminal("library_names");
            NonTerminal libraryName = new NonTerminal("library_name");
            NonTerminal useClause = new NonTerminal("use_clause");
            NonTerminal useNames = new NonTerminal("use_names");
            NonTerminal useName = new NonTerminal("use_name");
            NonTerminal identifierSeries = new NonTerminal("identifier_series");
            NonTerminal libraryUnit = new NonTerminal("library_unit");

            NonTerminal entityDeclaration = new NonTerminal("entity_declaration");
            NonTerminal entityHeader = new NonTerminal("entity_header");
            NonTerminal genericClause = new NonTerminal("generic_clause");
            NonTerminal portClause = new NonTerminal("port_clause");
            NonTerminal interfaceList = new NonTerminal("interface_list");
            NonTerminal objectDeclaration = new NonTerminal("object_declaration");
            NonTerminal objectType = new NonTerminal("object_type");
            NonTerminal identifierList = new NonTerminal("identifier_list");
            NonTerminal objectMode = new NonTerminal("object_mode");
            NonTerminal subtypeIndication = new NonTerminal("subtype_indication");
            NonTerminal rangeConstraint = new NonTerminal("range_constraint");
            NonTerminal direction = new NonTerminal("direction");

            NonTerminal architectureBody = new NonTerminal("architecture_body");
            NonTerminal architectureDeclarativePart = new NonTerminal("architecture_declarative_part");
            NonTerminal blockDeclarativeItem = new NonTerminal("block_declarative_item");
            NonTerminal componentDeclaration = new NonTerminal("component_declaration");
            NonTerminal attributeSpecification = new NonTerminal("attribute_specification");

            NonTerminal architectureStatementPart = new NonTerminal("architecture_statement_part");
            NonTerminal concurrentStatement = new NonTerminal("concurrent_statement");
            NonTerminal concurrentSignalAssignmentStatement = new NonTerminal("concurrent_signal_assignment_statement");
            NonTerminal name = new NonTerminal("name");
            NonTerminal simpleName = new NonTerminal("simple_name");
            NonTerminal indexedName = new NonTerminal("indexed_name");
            NonTerminal sliceName = new NonTerminal("slice_name");

            NonTerminal componentInstatiationStatement = new NonTerminal("component_instantiation_statement");
            NonTerminal genericMapAspect = new NonTerminal("generic_map_aspect");
            NonTerminal associationList = new NonTerminal("association_list");
            NonTerminal associationElement = new NonTerminal("association_element");
            NonTerminal portMapAspect = new NonTerminal("port_map_aspect");

            NonTerminal expression = new NonTerminal("expression");
            NonTerminal andExpression = new NonTerminal("and_expression");
            NonTerminal orExpression = new NonTerminal("or_expression");
            NonTerminal xorExpression = new NonTerminal("xor_expression");
            NonTerminal nandExpression = new NonTerminal("nand_expression");
            NonTerminal norExpression = new NonTerminal("nor_expression");
            NonTerminal xnorExpression = new NonTerminal("xnor_expression");
            NonTerminal factor = new NonTerminal("factor");
            NonTerminal primary = new NonTerminal("primary");

            designFile.Rule = MakePlusRule(designFile, designUnit);
            designUnit.Rule = contextClause + libraryUnit;

            contextClause.Rule = MakeStarRule(contextClause, contextItem);
            contextItem.Rule = libraryClause | useClause;
            libraryClause.Rule = sLibrary + libraryNames + sSemicolon;
            libraryNames.Rule = MakePlusRule(libraryNames, sComma, libraryName);
            libraryName.Rule = sIdentifier;
            useClause.Rule = sUse + useNames + sSemicolon;
            useNames.Rule = MakePlusRule(useNames, sComma, useName);

            useName.Rule = identifierSeries + (sPeriod + sAll).Q();
            identifierSeries.Rule = MakePlusRule(identifierSeries, sPeriod, sIdentifier);


            libraryUnit.Rule = entityDeclaration + architectureBody;


            entityDeclaration.Rule =
                sEntity + sIdentifier + sIs +
                entityHeader +
                sEnd + sEntity.Q() + sIdentifier.Q() + sSemicolon;


            entityHeader.Rule = genericClause.Q() + portClause.Q();
            genericClause.Rule = sGeneric + sLParen + interfaceList + sRParen + sSemicolon;
            portClause.Rule = sPort + sLParen + interfaceList + sRParen + sSemicolon;
            interfaceList.Rule = MakePlusRule(interfaceList, sSemicolon, objectDeclaration);
            objectDeclaration.Rule = objectType.Q() + identifierList + sColon + objectMode.Q() + subtypeIndication + (sSeqAssign + expression).Q();

            objectType.Rule = sAttribute | sConstant | sSignal | sVariable | sFile;
            identifierList.Rule = MakePlusRule(identifierList, sComma, sIdentifier);
            objectMode.Rule = sIn | sOut | sInout | sBuffer | sLinkage;
            subtypeIndication.Rule = sIdentifier + (sLParen + rangeConstraint + sRParen).Q();
            rangeConstraint.Rule = sNumber + direction + sNumber;
            direction.Rule = sTo | sDownto;

            architectureBody.Rule =
                sArchitecture + sIdentifier + sOf + sIdentifier + sIs +
                architectureDeclarativePart +
                sBegin +
                architectureStatementPart +
                sEnd + sArchitecture.Q() + sIdentifier.Q() + sSemicolon;
            architectureDeclarativePart.Rule = MakeStarRule(architectureDeclarativePart, blockDeclarativeItem);
            blockDeclarativeItem.Rule = componentDeclaration | objectDeclaration + sSemicolon | attributeSpecification;
            componentDeclaration.Rule =
                sComponent + sIdentifier + sIs.Q() +
                genericClause.Q() +
                portClause.Q() +
                sEnd + sComponent + sIdentifier.Q() + sSemicolon;
            attributeSpecification.Rule = sAttribute + sIdentifier + sOf + sIdentifier + sIs + expression + sSemicolon;

            architectureStatementPart.Rule = MakeStarRule(architectureStatementPart, concurrentStatement);
            concurrentStatement.Rule = concurrentSignalAssignmentStatement | componentInstatiationStatement;
            concurrentSignalAssignmentStatement.Rule = name + sAssign + expression + sSemicolon;
            name.Rule = simpleName | indexedName | sliceName;
            simpleName.Rule = sIdentifier;
            indexedName.Rule = sIdentifier + sLParen + sNumber + sRParen;
            sliceName.Rule = sIdentifier + sLParen + rangeConstraint + sRParen;

            componentInstatiationStatement.Rule = sIdentifier + sColon + sComponent.Q() + sIdentifier + genericMapAspect.Q() + portMapAspect.Q() + sSemicolon;
            genericMapAspect.Rule = sGeneric + sMap + sLParen + associationList + sRParen;
            associationList.Rule = MakePlusRule(associationList, sComma, associationElement);
            associationElement.Rule = name + sRArrow + name;
            portMapAspect.Rule = sPort + sMap + sLParen + associationList + sRParen;

            expression.Rule = andExpression | orExpression | xorExpression | nandExpression | norExpression | xnorExpression;
            andExpression.Rule = MakePlusRule(andExpression, sAnd, factor);
            orExpression.Rule = MakePlusRule(orExpression, sOr, factor);
            xorExpression.Rule = MakePlusRule(xorExpression, sXor, factor);
            nandExpression.Rule = MakePlusRule(nandExpression, sNand, factor);
            norExpression.Rule = MakePlusRule(norExpression, sNor, factor);
            xnorExpression.Rule = MakePlusRule(xnorExpression, sXnor, factor);
            factor.Rule = primary | sNot + primary;
            primary.Rule = name | sLParen + expression + sRParen;


            Root = designFile;
        }
    }
}
