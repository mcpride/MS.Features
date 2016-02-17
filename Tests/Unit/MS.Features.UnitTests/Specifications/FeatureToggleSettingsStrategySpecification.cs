using Microsoft.VisualStudio.TestTools.UnitTesting;
using MS.Features.Strategies.Configuration;
using MS.Features.Strategies.Providers;
using MS.Features.UnitTests.Features;
using MS.QualityTools.UnitTestFramework.Specifications;

namespace MS.Features.UnitTests.Specifications
{
    [TestClass]
    [SpecificationDescription("FeatureToggleSettingsStrategy Tests")]
    [DeploymentItem("featureToggles.config")]
    public class FeatureToggleSettingsStrategySpecification : FeatureSpecificationBase
    {
        [TestMethod]
        [ScenarioDescription("Reading of a feature-toggle settings strategy disabled feature succeeds")]
        public void Reading_of_a_FeatureToggleSettings_disabled_feature_succeeds()
        {
            Given("a FeatureToggleSettings disabled feature", ctx =>
            {
            })
                .When("Setup with FeatureToggleSettingsStrategy configured feature is done", ctx =>
                {
                    var builder = new FeatureSetBuilder();
                    builder.Build(fctx =>
                    {
                        fctx.AddFeature<DisabledFeatureToggleSettingsSampleFeature>();
                        fctx.ForConfiguration<FeatureToggleSettingsStrategyAttribute>().Use<FeatureToggleSettingsStrategyProvider>();
                    });
                })
                .Then("FeatureToggleSettingsStrategy configured feature should be disabled",
                    ctx => !FeatureContext.IsEnabled<DisabledFeatureToggleSettingsSampleFeature>());
        }

        [TestMethod]
        [ScenarioDescription("Reading of a feature-toggle settings strategy enabled feature succeeds")]
        public void Reading_of_a_FeatureToggleSettings_enabled_feature_succeeds()
        {
            Given("a FeatureToggleSettings enabled feature", ctx =>
            {
            })
                .When("Setup with FeatureToggleSettingsStrategy configured feature is done", ctx =>
                {
                    var builder = new FeatureSetBuilder();
                    builder.Build(fctx =>
                    {
                        fctx.AddFeature<EnabledFeatureToggleSettingsSampleFeature>();
                        fctx.ForConfiguration<FeatureToggleSettingsStrategyAttribute>().Use<FeatureToggleSettingsStrategyProvider>();
                    });
                })
                .Then("FeatureToggleSettingsStrategy configured feature should be enabled",
                    ctx => FeatureContext.IsEnabled<EnabledFeatureToggleSettingsSampleFeature>());
        }
    }
}
