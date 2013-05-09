using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Appy.Core;
using System.Collections.Generic;
using System.Collections.Specialized;
using RazorEngine.Configuration;
using RazorEngine;
using RazorEngine.Templating;
using Moq;

namespace Appy.ExampleApp.Tests
{
    [TestClass]
    public class ExampleControllerTests
    {
        [TestInitialize]
        public void SetupTemplateResolver()
        {
            var mock = new Mock<ITemplateResolver>();
            mock.Setup(x => x.Resolve(It.IsAny<string>())).Returns("Mocked View Content.");

            var razorConfig = new TemplateServiceConfiguration { Resolver = mock.Object};
            Razor.SetTemplateService(new TemplateService(razorConfig));
        }

        [TestMethod]
        public void Verify_Launcher_SendsCookie()
        {
            var controller = new ExampleController();

            var response = controller.Launcher(null);

            Assert.IsTrue(response.StatusCode == 200);
            Assert.AreEqual("abc", response.Cookies["testCookie"].Value);
        }

        [TestMethod]
        public void Verify_Launcher_SendsHeader()
        {
            var controller = new ExampleController();

            var response = controller.Launcher(null);

            Assert.IsTrue(response.StatusCode == 200);
            Assert.AreEqual("123", response.Headers["testHeader"]);
        }

        [TestMethod]
        public void Verify_ChangeTheme_Redirects()
        {
            var controller = new ExampleController();
            var request = new Request
            {
                QueryString = new NameValueCollection { { "theme", "JaffasTheme"} }
            };

            var response = controller.ChangeTheme(request);

            Assert.IsTrue(response.StatusCode == 302);
            Assert.AreEqual("/testing", response.Headers["Location"]);
        }
    }
}
