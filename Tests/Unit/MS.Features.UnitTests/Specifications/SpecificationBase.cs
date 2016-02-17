using System;
using MS.QualityTools.UnitTestFramework.Specifications;

namespace MS.Features.UnitTests.Specifications
{
    public abstract class SpecificationBase : Specification
    {
        public Exception Throws(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }
    }

}
