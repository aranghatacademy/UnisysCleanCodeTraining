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

namespace NamesSpaceAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class NamesSpaceAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "ART001";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/main/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = "Namespace must be of the format Company.Product.Feature";
        private static readonly LocalizableString MessageFormat = "Namespace '{0}' does not start with 'Company.Product.Feature'";
        private static readonly LocalizableString Description = "Namespaces must begin with 'Company.Product.Feature'. e.g Aranghat.MyAwsomeProcut.Access";
        private const string Category = "Naming";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat
            , Category
            , DiagnosticSeverity.Error
            , isEnabledByDefault: true
            , description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

           
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Namespace);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var nameSpaceName = ((INamespaceSymbol)context.Symbol).ToDisplayString();
            var isValid =  Regex.IsMatch(nameSpaceName, "^Aranghat\\.[A-Z][a-zA-Z0-9]*\\.[A-Z][a-zA-Z0-9]*$");

            // Find just those named type symbols with names containing lowercase letters.
            if (!isValid)
            {
                // For all such symbols, produce a diagnostic.
                var diagnostic = Diagnostic.Create(Rule, context.Symbol.Locations[0], nameSpaceName);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
