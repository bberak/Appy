using SelfServe;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace Appy.Tests
{
    [TestClass]
    public class ControllerTests
    {
        Controller MockedController;

        public ControllerTests()
        {
            MockedController = new Mock<Controller>().Object;
        }

        [TestMethod]
        public void Verify_BasicMethod_ReturnsBasicResponse()
        {
            Response response = MockedController.Basic("Testing 123", 200);

            Assert.IsTrue(response is BasicResponse);
            Assert.IsTrue(
                "Testing 123"
                .ToBytes()
                .Matches(response.ToBytes())
                );
            Assert.AreEqual("text/html; charset=UTF-8", response.ContentType);
        }

        [TestMethod]
        public void Verify_JsonMethod_ReturnsJsonResponse()
        {
            var model = new { Field1 = "abc", Field2 = 123 };
            Response response = MockedController.Json(model);

            Assert.IsTrue(response is JsonResponse);
            Assert.IsTrue(
                JsonConvert.SerializeObject(model)
                .ToBytes()
                .Matches(response.ToBytes())
                );
            Assert.AreEqual("application/json", response.ContentType);
        }
    }
}
