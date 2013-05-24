using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Appy.Tests
{
    [TestClass]
    public class BootstrapTaskTests
    {
        string NewPath = @"C:\AppyTesting";

        [TestCleanup]
        public void CleanUp()
        {
            Directory.Delete(NewPath);
        }

        [TestMethod]
        public void CreatePathTask_Verify_NewPath()
        {
            var task = new CreateFolderTask(NewPath);

            task.Run();

            Assert.IsTrue(Directory.Exists(NewPath));
        }

        [TestMethod]
        public void Verify_RunMethod_CreatesProject()
        {
            throw new NotImplementedException();
        }
    }
}
