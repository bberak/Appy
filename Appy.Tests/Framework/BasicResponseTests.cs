using SelfServe;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Appy.Tests
{
    [TestClass]
    public class BasicResponseTests
    {
        BasicResponse Response;
        const string CONTENT = "Some random content";

        public BasicResponseTests()
        {
            Response = new BasicResponse(CONTENT);
        }

        [TestMethod]
        public void Verify_ContentType_TextOrHtml()
        {
            Assert.AreEqual<string>("text/html; charset=UTF-8", Response.ContentType);
        }

        [TestMethod]
        public void Verify_ToBytes_IsCorrect()
        {
            Assert.IsTrue(CONTENT.ToBytes().Matches(Response.ToBytes()));
        }

        [TestMethod]
        public void Verify_DefaultStatusCode_200()
        {
            int expectedStatusCode = 200;

            Assert.AreEqual<int>(expectedStatusCode, Response.StatusCode);
        }
    }
}
