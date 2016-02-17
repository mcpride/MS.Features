using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MS.Features.Strategies.Configuration;
using MS.Features.Strategies.Providers;
using MS.Features.UnitTests.Features;
using MS.QualityTools.UnitTestFramework.Specifications;

namespace MS.Features.UnitTests.Specifications
{
    [TestClass]
    [SpecificationDescription("HttpSessionStrategy Tests")]
    public class HttpSessionStrategySpecification : FeatureSpecificationBase
    {
        [TestMethod]
        [ScenarioDescription("Reading of a HttpSession enabled feature succeeds")]
        public void Reading_of_a_HttpSession_enabled_feature_succeeds()
        {
            Given("a HttpContext", ctx =>
            {
                var httpContextMock = new Mock<HttpContextBase>();
                var httpSessionStateMock = new Mock<HttpSessionStateBase>();
                httpContextMock.Setup(m => m.Session).Returns(() => httpSessionStateMock.Object);
                httpContextMock.SetupGet(m => m.Session["HttpSessionSample"]).Returns("true");
                HttpContextFactory.SetCurrentContext(httpContextMock.Object);
            })
                .When("Setup with HttpSessionStrategy configured feature is done", ctx =>
                {
                    var builder = new FeatureSetBuilder();
                    builder.Build(fctx =>
                    {
                        fctx.AddFeature<HttpSessionSampleFeature>();
                        fctx.ForConfiguration<HttpSessionStrategyAttribute>().Use<HttpSessionStrategyProvider>();
                    });
                })
                .Then("HttpSessionStrategy configured feature should be enabled",
                    ctx => FeatureContext.IsEnabled<HttpSessionSampleFeature>());
        }

        [TestMethod]
        [ScenarioDescription("Reading of a HttpSession disabled feature succeeds")]
        public void Reading_of_a_HttpSession_disabled_feature_succeeds()
        {
            Given("a HttpContext", ctx =>
            {
                var httpContextMock = new Mock<HttpContextBase>();
                var httpSessionStateMock = new Mock<HttpSessionStateBase>();
                httpContextMock.Setup(m => m.Session).Returns(() => httpSessionStateMock.Object);
                httpContextMock.SetupGet(m => m.Session["HttpSessionSample"]).Returns("false");
                HttpContextFactory.SetCurrentContext(httpContextMock.Object);
            })
                .When("Setup with HttpSessionStrategy configured feature is done", ctx =>
                {
                    var builder = new FeatureSetBuilder();
                    builder.Build(fctx =>
                    {
                        fctx.AddFeature<HttpSessionSampleFeature>();
                        fctx.ForConfiguration<HttpSessionStrategyAttribute>().Use<HttpSessionStrategyProvider>();
                    });
                })
                .Then("HttpSessionStrategy configured feature should be disabled",
                    ctx => !FeatureContext.IsEnabled<HttpSessionSampleFeature>());
        }

        [TestMethod]
        [ScenarioDescription("Feature not configured in HttpSession is disabled")]
        public void Feature_not_configured_in_HttpSession_is_disabled()
        {
            Given("a HttpContext", ctx =>
            {
                var httpContextMock = new Mock<HttpContextBase>();
                var httpSessionStateMock = new Mock<HttpSessionStateBase>();
                httpContextMock.Setup(m => m.Session).Returns(() => httpSessionStateMock.Object);
                HttpContextFactory.SetCurrentContext(httpContextMock.Object);
            })
                .When("Setup with HttpSessionStrategy configured feature is done", ctx =>
                {
                    var builder = new FeatureSetBuilder();
                    builder.Build();
                    //builder.Build(fctx =>
                    //{
                    //    fctx.AddFeature<HttpSessionSampleFeature>();
                    //    fctx.ForConfiguration<HttpSessionAttribute>().Use<HttpSessionStrategy>();
                    //});
                })
                .Then("HttpSessionStrategy configured feature should be disabled",
                    ctx => !FeatureContext.IsEnabled<HttpSessionSampleFeature>());
        }
    }
}
