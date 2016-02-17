using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MS.Features.UnitTests.Specifications
{
    public abstract class FeatureSpecificationBase : SpecificationBase
    {
        [TestInitialize]
        public void Setup()
        {
            FeatureContext.Reset();
        } 
    }

}
