using System.Collections.Specialized;
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
    [SpecificationDescription("QueryStringStrategy Tests")]
    public class QueryStringStrategySpecification : FeatureSpecificationBase
    {
        [TestMethod]
        [ScenarioDescription("Reading of a QueryString enabled feature succeeds")]
        public void Reading_of_a_QueryString_enabled_feature_succeeds()
        {
            Given("a HttpContext", ctx =>
            {
                var httpContextMock = new Mock<HttpContextBase>();
                var httpRequestMock = new Mock<HttpRequestBase>();
                var queryStrings = new NameValueCollection
                {
                    {"QueryStringSample", "true"}
                };
                httpRequestMock.SetupGet(r => r.QueryString).Returns(queryStrings);
                httpContextMock.Setup(b => b.Request).Returns(() => httpRequestMock.Object);
                HttpContextFactory.SetCurrentContext(httpContextMock.Object);
            })
                .When("Setup with QueryStringStrategy configured feature is done", ctx =>
                {
                    var builder = new FeatureSetBuilder();
                    builder.Build(fctx =>
                    {
                        fctx.AddFeature<QueryStringSampleFeature>();
                        fctx.ForConfiguration<QueryStringStrategyAttribute>().Use<QueryStringStrategyProvider>();
                    });
                })
                .Then("QueryStringStrategy configured feature should be enabled",
                    ctx => FeatureContext.IsEnabled<QueryStringSampleFeature>());
        }

        [TestMethod]
        [ScenarioDescription("Reading of a QueryString disabled feature succeeds")]
        public void Reading_of_a_QueryString_disabled_feature_succeeds()
        {
            Given("a HttpContext", ctx =>
            {
                var httpContextMock = new Mock<HttpContextBase>();
                var httpRequestMock = new Mock<HttpRequestBase>();
                var queryStrings = new NameValueCollection
                {
                    {"QueryStringSample", "false"}
                };
                httpRequestMock.SetupGet(r => r.QueryString).Returns(queryStrings);
                httpContextMock.Setup(b => b.Request).Returns(() => httpRequestMock.Object);
                HttpContextFactory.SetCurrentContext(httpContextMock.Object);
            })
                .When("Setup with QueryStringStrategy configured feature is done", ctx =>
                {
                    var builder = new FeatureSetBuilder();
                    builder.Build(fctx =>
                    {
                        fctx.AddFeature<QueryStringSampleFeature>();
                        fctx.ForConfiguration<QueryStringStrategyAttribute>().Use<QueryStringStrategyProvider>();
                    });
                })
                .Then("QueryStringStrategy configured feature should be disabled",
                    ctx => !FeatureContext.IsEnabled<QueryStringSampleFeature>());
        }

        [TestMethod]
        [ScenarioDescription("Feature not configured in QueryString is disabled")]
        public void Feature_not_configured_in_QueryString_is_disabled()
        {
            Given("a HttpContext", ctx =>
            {
                var httpContextMock = new Mock<HttpContextBase>();
                var httpRequestMock = new Mock<HttpRequestBase>();
                httpContextMock.Setup(b => b.Request).Returns(() => httpRequestMock.Object);
                HttpContextFactory.SetCurrentContext(httpContextMock.Object);
            })
                .When("Setup with QueryStringStrategy configured feature is done", ctx =>
                {
                    var builder = new FeatureSetBuilder();
                    builder.Build(fctx =>
                    {
                        fctx.AddFeature<QueryStringSampleFeature>();
                        fctx.ForConfiguration<QueryStringStrategyAttribute>().Use<QueryStringStrategyProvider>();
                    });
                })
                .Then("QueryStringStrategy configured feature should be disabled",
                    ctx => !FeatureContext.IsEnabled<QueryStringSampleFeature>());
        }
    }
}
