using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace ClassNameAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ClassNameAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "CUT001";

        private static readonly LocalizableString Title = "Invalid Class Name";
        private static readonly LocalizableString MessageFormat = "Class Name '{0}' should contain only Alphabets ";
        private static readonly LocalizableString Description = "Class Name must be PascalCase and must contain only Alphabets and no Special chars or numbers";
        private const string Category = "Naming";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category
            , DiagnosticSeverity.Error
            , isEnabledByDefault: true
            , description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public static Regex PascalCaseClassNameRegex = new Regex("^[A-Z][a-zA-Z]+$",RegexOptions.Compiled);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

           
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
        }

       
        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var className = context.Symbol.Name;
            if(!PascalCaseClassNameRegex.IsMatch(className))
            {
                
                var diagnostic = Diagnostic.Create(Rule, context.Symbol.Locations[0], context.Symbol.Name);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
