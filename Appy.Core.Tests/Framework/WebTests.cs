using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace Appy.Core.Tests.Framework
{
    [TestClass]
    public class WebTests
    {
        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void Get_Page_With_Invalid_Url()
        {
            var result = Web.Get("blah://dontexist.com/index.html");
        }

        [TestMethod]
        public void TryGet_Page_With_Invalid_Url()
        {
            var result = Web.TryGet("blah://dontexist.com/index.html", "error");

            Assert.AreEqual("error", result);
        }

        [TestMethod]
        public void Get_Page_With_Valid_Url()
        {
            var result = Web.Get("http://google.com");

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void TryGet_Page_With_Valid_Url()
        {
            var result = Web.TryGet("http://google.com", "error");

            Assert.IsTrue(result.Length > 0);
            Assert.AreNotEqual("error", result);
        }
    }
}
