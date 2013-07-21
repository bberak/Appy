using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;
using SelfServe.Tests;
using SelfServe;
using System.Net;

namespace Appy.Core.Tests
{
    [TestClass]
    public class AppyRouterTests : TestBase
    {
        AppyRouter Router;

        public AppyRouterTests()
        {
            Router = new AppyRouter();
            Router.LoadRoutesFrom(Assembly.GetExecutingAssembly());
        }

        void HandleRequest(object sender, RequestReceivedArgs e)
        {
            try
            {
                Router.TryHandleRequest(e.Request, e.Response);
            }
            catch (TargetParameterCountException)
            {
                e.Response.StatusCode = 500;
                e.Response.WriteText("Exception was thrown.");
            }
        }

        [Url("/Route1")]
        public void Route1()
        {
            throw new NotImplementedException();
        }

        [Url("/Route2")]
        public Response Route2(Request incoming)
        {
            return new BasicResponse("Reached Route2");
        }

        [TestMethod]
        public void Verify_UrlRoutes_AreFound()
        {
            Assert.IsTrue(Router.UrlRouteCount == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void Verify_BadRoute_ThrowsException()
        {
            using (HttpServer server = CreateServer())
            {
                //-- Arrange       
                server.RequestReceived += HandleRequest;
                server.Start();

                //-- Act 
                var response = CreateRequest(path: "Route1").GetResponse();
            }
        }

        [TestMethod]
        public void Verify_GoodRoute_Returns200()
        {
            using (HttpServer server = CreateServer())
            {
                //-- Arrange       
                server.RequestReceived += HandleRequest;
                server.Start();

                //-- Act 
                var response = CreateRequest(path: "Route2").GetResponse() as HttpWebResponse;

                //-- Assert
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual("Reached Route2", response.GetContents());
            }
        }

        [Catches]
        public void HandleDefaultExceptions(Exception ex)
        {
            if (ex is IndexOutOfRangeException)
                throw ex;
        }

        [Catches(typeof(FileNotFoundException))]
        public void HandleSpecificException(FileNotFoundException ex)
        {

        }

        [TestMethod]
        public void Verify_ExceptionRoutes_AreFound()
        {
            Assert.IsTrue(Router.ExceptionRouteCoumt == 2);
        }

        [TestMethod]
        public void Verify_FileNotFoundException_IsCaaught()
        {
            FileNotFoundException ex = new FileNotFoundException();

            Router.TryHandleException(ex);
        }

        [TestMethod]
        public void Verify_FieldAccessException_IsCaaught()
        {
            FieldAccessException ex = new FieldAccessException();

            Router.TryHandleException(ex);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Verify_IndexOutOfRangeException_IsCaaughtAndThrown()
        {
            IndexOutOfRangeException ex = new IndexOutOfRangeException();

            Router.TryHandleException(ex);
        }
    }
}
