using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using SelfServe.Tests;
using SelfServe;
using System.Net;

namespace Appy.Core.Tests
{
    [TestClass]
    public class UrlRouterTests : TestBase
    {
        UrlRouter Router;

        public UrlRouterTests()
        {
            Router = new UrlRouter();
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
            Assert.IsTrue(Router.RouteCount == 2);
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
    }
}
