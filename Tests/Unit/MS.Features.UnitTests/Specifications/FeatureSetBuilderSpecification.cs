using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MS.Features.Strategies.Configuration;
using MS.Features.Strategies.Providers;
using MS.Features.UnitTests.Features;
using MS.QualityTools.UnitTestFramework.Specifications;

namespace MS.Features.UnitTests.Specifications
{
    [TestClass]
    [SpecificationDescription("FeatureSetBuilder Tests")]
    public class FeatureSetBuilderSpecification : FeatureSpecificationBase
    {
        
        
        [TestMethod]
        [ScenarioDescription("Auto discovery returns right state of appSettings features")]
        public void AutoDiscovery_Success()
        {
            Given("a builder", ctx => ctx.State.Builder = new FeatureSetBuilder())
                .When("builder builds with auto discovery",
                    ctx => ctx.State.Container = ((FeatureSetBuilder) ctx.State.Builder).Build())
                .Then("feature 'EnabledAppSettingsSampleFeatureA' should be enabled",
                    ctx => FeatureContext.IsEnabled<EnabledAppSettingsSampleFeatureA>())
                .And("feature 'EnabledAppSettingsSampleFeatureB' should be enabled",
                    ctx => ((FeatureSet) ctx.State.Container).IsEnabled<EnabledAppSettingsSampleFeatureB>())
                .And("feature 'DisabledAppSettingsSampleFeatureC' shouldn't be enabled",
                    ctx => !FeatureContext.IsEnabled<DisabledAppSettingsSampleFeatureC>())
                .And("feature 'DisabledAppSettingsSampleFeatureD' shouldn't be enabled",
                    ctx => !((FeatureSet) ctx.State.Container).IsEnabled<DisabledAppSettingsSampleFeatureD>());
        }

        [TestMethod]
        [ScenarioDescription("Add same feature multiple times does not fail")]
        public void Add_same_feature_multiple_times_does_not_fail()
        {
            Given("a builder", ctx => ctx.State.Builder = new FeatureSetBuilder())
                .When("builder builds with same feature added twice",
                    ctx => ctx.State.Error = Throws(() =>  ctx.State.Container = ((FeatureSetBuilder)ctx.State.Builder).Build(
                        fc =>
                        {
                            fc.AddFeature<EnabledAppSettingsSampleFeatureA>();
                            fc.AddFeature<EnabledAppSettingsSampleFeatureA>();
                        })))
                .And("the feature is checked", ctx => FeatureContext.IsEnabled<EnabledAppSettingsSampleFeatureA>())
                .Then("it should not failed",
                    ctx => ((Exception)ctx.State.Error) == null);
        }

        [TestMethod]
        [ScenarioDescription("Call 'FeatureContext' without setup throws an error")]
        public void Call_FeatureContext_without_setup_throws_error()
        {
            Given("a 'FeatureContext' without setup", ctx => { })
                .When("a feature is checked",
                    ctx => ctx.State.Error = Throws(() => FeatureContext.IsEnabled<EnabledAppSettingsSampleFeatureA>()))
                .Then("an 'InvalidOperationException' should be thrown", ctx =>
                {
                    ((Exception) ctx.State.Error).Should().BeOfType<InvalidOperationException>();
                    return true;
                });
        }

        [TestMethod]
        [ScenarioDescription("AppSettings enabled feature with 'AlwaysFalseStrategy' should be disabled")]
        public void AppSettings_enabled_feature_with_AlwaysFalseStrategy_should_be_disabled()
        {
            Given("a builder", ctx => ctx.State.Builder = new FeatureSetBuilder())
                .When("builder builds with an appSettings enabled feature with 'AlwaysFalseStrategy'",
                    ctx => ctx.State.Container = ((FeatureSetBuilder) ctx.State.Builder).Build(
                        fc =>
                        {
                            fc.AddFeature<EnabledAppSettingsSampleFeatureA>();
                            fc.ForConfiguration<AppSettingsStrategyAttribute>().Use<AlwaysFalseStrategyProvider>();
                        }))
                .Then("the feature should be disabled",
                    ctx => !FeatureContext.IsEnabled<EnabledAppSettingsSampleFeatureA>());
        }

        [TestMethod]
        [ScenarioDescription("AppSettings disabled feature with 'AlwaysTrueStrategy' should be enabled")]
        public void AppSettings_disabled_feature_with_AlwaysTrueStrategy_should_be_enabled()
        {
            Given("a builder", ctx => ctx.State.Builder = new FeatureSetBuilder())
                .When("builder builds with an appSettings disabled feature with 'AlwaysTrueStrategy'",
                    ctx => ctx.State.Container = ((FeatureSetBuilder)ctx.State.Builder).Build(
                        fc =>
                        {
                            fc.AddFeature<DisabledAppSettingsSampleFeatureC>();
                            fc.ForConfiguration<AppSettingsStrategyAttribute>().Use<AlwaysTrueStrategyProvider>();
                        }))
                .Then("the feature should be enabled",
                    ctx => FeatureContext.IsEnabled<DisabledAppSettingsSampleFeatureC>());
        }
    }
}
