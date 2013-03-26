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

        public BasicResponseTests()
        {
            Response = new BasicResponse("Some random content");
        }

        [TestMethod]
        public void Verify_ContentType_TextOrHtml()
        {
            Assert.AreEqual<string>("text/html; charset=UTF-8", Response.ContentType);
        }

        [TestMethod]
        public void Verify_Content_ExpectedBytes()
        {
            byte[] contentInBytes = "Some random content".ToBytes();

            Assert.IsTrue(contentInBytes.SequenceEqual(Response.ToBytes()));
        }

        [TestMethod]
        public void Verify_DefaultStatusCode_200()
        {
            int expectedStatusCode = 200;

            Assert.AreEqual<int>(expectedStatusCode, Response.StatusCode);
        }
    }
}
