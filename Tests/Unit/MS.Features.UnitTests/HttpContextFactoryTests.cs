using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MS.Features.UnitTests.Mocks;

namespace MS.Features.UnitTests
{
    [TestClass]
    public class HttpContextFactoryTests
    {
        [TestMethod]
        public void Getting_Current_Context_while_HttpContext_Current_is_unassigned_throws_InvalidOperationException()
        {
            //Arrange
            HttpContextFactory.SetCurrentContext(null);

            //Act
            Action readingCurrentContext = () => { var ctx = HttpContextFactory.Current; };
            
            //Assert
            readingCurrentContext.ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void Getting_Current_Context_while_HttpContext_Current_is_assigned_succeeds()
        {
            //Arrange
            HttpContextFactory.SetCurrentContext(null);

            using (new HttpSimulator("/", @"c:\inetpub\").SimulateRequest())
            {
                //Act
                var ctx = HttpContextFactory.Current;

                //Assert
                ctx.Should().NotBeNull();
            }
        }
    }
}
