using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Appy.Core.Tests
{
    [TestClass]
    public class JsonResponseTests
    {
        JsonResponse Response;
        object Model;

        public JsonResponseTests()
        {
            Model = new { Field1 = "abc", Field2 = 123 };
            Response = new JsonResponse(Model);
        }

        [TestMethod]
        public void Verify_ContentType_IsCorrect()
        {
            Assert.AreEqual("application/json", Response.ContentType);
        }

        [TestMethod]
        public void Verify_Model_IsSerialized()
        {
            Assert.IsFalse(string.IsNullOrEmpty(Response.Content));
            Assert.AreEqual(JsonConvert.SerializeObject(Model), Response.Content);
        }
    }
}
