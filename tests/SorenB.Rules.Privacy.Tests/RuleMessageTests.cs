using Xunit;

namespace SorenB.Rules.Privacy.Tests
{
    public class RuleMessageTests
    {
        /// <summary>The link comes from BrandDocsUrlFormat in Directory.Build.props. This pins the published URL so a change there is deliberate.</summary>
        [Fact]
        public void Documentation_link_points_to_the_rule_page()
        {
            Assert.Equal(
                "https://github.com/sorenbcoding/privacy-compliance-rules/blob/main/docs/rules/SB-SEC-001.md",
                RuleMessage.DocumentationLink("SB-SEC-001"));
        }
    }
}
