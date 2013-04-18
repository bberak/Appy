using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;

namespace Appy.Tests
{
    [TestClass]
    public class ExceptionRouterTests
    {
        ExceptionRouter Router;

        public ExceptionRouterTests()
        {
            Router = new ExceptionRouter();
            Router.LoadRoutesFrom(Assembly.GetExecutingAssembly());
        }

        [Catches]
        public void HandleDefaultExceptions(Exception ex)
        {
            if (ex is ExecutionEngineException)
                throw ex;
        }

        [Catches(typeof(FileNotFoundException))]
        public void HandleSpecificException(FileNotFoundException ex)
        {

        }

        [TestMethod]
        public void Verify_ExceptionRoutes_AreFound()
        {
            Assert.IsTrue(Router.RouteCount == 2);
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
        [ExpectedException(typeof(ExecutionEngineException))]
        public void Verify_ExecutionEngineException_IsCaaughtAndThrown()
        {
            ExecutionEngineException ex = new ExecutionEngineException();

            Router.TryHandleException(ex);
        }
    }
}
