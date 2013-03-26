using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Appy.Tests
{
    [TestClass]
    public class TemplateResolverTests
    {
        [TestMethod]
        public void Resolve_ExistingView_Found()
        {
            TemplateResolver resolver = new TemplateResolver();

            string path = resolver.Resolve("index.html");

            Assert.IsNotNull(path);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Resolve_MissingView_Exception()
        {
            TemplateResolver resolver = new TemplateResolver();

            string path = resolver.Resolve("dontexist.html");

            Assert.Fail();
        }
    }
}
