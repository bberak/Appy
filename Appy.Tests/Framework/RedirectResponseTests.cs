using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Appy.Tests
{
    [TestClass]
    public class RedirectResponseTests
    {
        RedirectResponse Response;

        public RedirectResponseTests()
        {
            Response = new RedirectResponse("https://github.com/bberak");
        }

        [TestMethod]
        public void Check_LocationHeader_IsCorrect()
        {
            string headerName = "Location";
            string headerValue = "https://github.com/bberak";

            Assert.AreEqual(headerValue, Response.Headers[headerName]);
        }

        [TestMethod]
        public void Verify_DefaultStatusCode_302()
        {
            int expectedStatusCode = 302;

            Assert.AreEqual<int>(expectedStatusCode, Response.StatusCode);
        }
    }
}
