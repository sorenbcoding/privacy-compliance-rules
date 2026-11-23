using System.Globalization;
using System.Reflection;

namespace SorenB.Rules.Privacy
{
    /// <summary>Builds messages in the SorenB pattern: what is wrong. Why it matters. How to fix.</summary>
    internal static class RuleMessage
    {
        /// <summary>URL format for a rule's help page, with {0} for the rule ID. Set by BrandDocsUrlFormat in Directory.Build.props.</summary>
        internal static readonly string DocumentationUrlFormat = ReadDocumentationUrlFormat();

        public static string Format(string what, string why, string fix)
            => $"{Clean(what)}. {Clean(why)}. {Clean(fix)}.";

        /// <summary>Link to the rule's own page, e.g. docs/rules/SB-SEC-001.md.</summary>
        public static string DocumentationLink(string ruleId)
            => string.Format(CultureInfo.InvariantCulture, DocumentationUrlFormat, ruleId);

        private static string Clean(string s) => s.Trim().TrimEnd('.', '!');

        private static string ReadDocumentationUrlFormat()
            => typeof(RuleMessage).Assembly
                .GetCustomAttributes<AssemblyMetadataAttribute>()
                .FirstOrDefault(a => a.Key == "DocsUrlFormat")?.Value
               ?? throw new InvalidOperationException("The DocsUrlFormat assembly metadata is missing. Set BrandDocsUrlFormat in Directory.Build.props.");
    }
}
