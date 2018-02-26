
using CIS.CodeDom.Csharp;

using System;

namespace CIS.CodeDom.DNA
{
    public interface IDNA
    {

        CsCompileUnit DNA { get; set; }

    }

    public class Oid : IDNA
    {
        public Oid()
        {
            _dna = new CsCompileUnit();
            CsNamespace ns = new CsNamespace(new CsIdentifier("System"));
            CsUsing u1 = new CsUsing(ns);
            _dna.Usings.Usings.Add(u1);
            CsNamespace cn = new CsNamespace(new CsIdentifier(ECsNames.Namespace));
            _dna.UnitMembers.Members.Add(cn);
            CsClass cl = new CsClass();
            ((ICsModifiersProvider)cl).Modifiers = null;
            ((ICsClass)cl).ClassName = new CsIdentifier("Program");
            cn.NamespaceMembers.Members.Add(cl);
            CsMethod m1 = new CsMethod(new CsIdentifier("Main"), null, null, null, null, null, null, null, null);
            ((ICsModifiersProvider)m1).Modifiers = new CsModifiers(ECsModifiers.Static);
            ((ICsMethod)m1).TypeResult = new CsTypeReference(new CsVoid());
            cl.Body.Members.Add(m1);
            CsMethod m2 = new CsMethod((new CsIdentifier("WriteLine")), null, null, null, null, null, null, null, null);
            CsExpressionCall cm1 = new CsExpressionCall(new CsMethodReference(m2), null);
            CsExpressionLiteral l1 = new CsExpressionLiteral(new CsLiteralString("message"));
            CsArgument a1 = new CsArgument(null, l1);
            ((ICsArgument)a1).ArgumentInitialisationType = ECsInitialisationType.Expression;
            cm1.Arguments.Arguments.Add(a1);
            CsExpressionName n1 = new CsExpressionName("Console");
            CsExpressionType t1 = new CsExpressionType(new CsTypeReference(typeof(System.Console), ECsReflectInfoStatus.ExternalDll), null);
            CsExpressionQualifiedExpression e1 = new CsExpressionQualifiedExpression(t1, cm1);
            ((ICsExpressionQualifiedExpression)e1).Access = ECsObjectAccess.Reference;
            CsStatementExpression s1 = new CsStatementExpression(e1);
            m1.Body.Statements.Statements.Add(s1);

            CsMethod m3 = new CsMethod(new CsIdentifier("ReadLine"), null, null, null, null, null, null, null, null);
            CsExpressionCall cm2 = new CsExpressionCall(new CsMethodReference(m3), null);
            CsExpressionQualifiedExpression e2 = new CsExpressionQualifiedExpression(t1, cm2);
            ((ICsExpressionQualifiedExpression)e2).Access = ECsObjectAccess.Reference;
            CsStatementExpression s2 = new CsStatementExpression(e2);
            m1.Body.Statements.Statements.Add(s2);
        }


        /// <summary>
                /// ДНК оид
                /// </summary>
        private CsCompileUnit _dna;



        /// <summary>
                /// свойства для возврата ДНК оида
                /// </summary>
        public CsCompileUnit DNA

        {
            get { return _dna; }
            set { _dna = value; }
        }

        /// <summary>
                /// свойство возврата исходного программного кода данного оида 
                /// </summary>
        public string Nature
        {
            get { return ((ICsCode)_dna).GenerateSourceCode(); }
        }
    }
}

