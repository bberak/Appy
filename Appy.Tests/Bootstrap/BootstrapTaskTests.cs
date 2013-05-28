using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Appy.Tests
{
    [TestClass]
    public class BootstrapTaskTests
    {
        string BaseTestFolder = @"C:\BootstrapTaskTests";

        [TestCleanup]
        public void CleanUp()
        {
            if (Directory.Exists(BaseTestFolder))
                Directory.Delete(BaseTestFolder, true);
        }

        [TestMethod]
        public void Verify_CreateFolderTask_NewPath()
        {
            var newFolder = Path.Combine(BaseTestFolder, "CreateFolderTest");
            var task = new CreateFolderTask(newFolder);

            task.Run();

            Assert.IsTrue(Directory.Exists(newFolder));
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void Verify_CopyFileTask_PathDoesNotExist()
        {
            var source = Path.GetTempFileName();
            var destination = @"C:\DoesNotExist\CopyFileTest\testing.txt";
            var task = new CopyFileTask(source, destination);

            task.Run();
        }

        [TestMethod]
        public void Verify_CopyFileTask_FileIsCopied()
        {
            var source = Path.GetTempFileName();
            var destinationFolder = Path.Combine(BaseTestFolder, "CopyFileTest");
            Directory.CreateDirectory(destinationFolder);
            var destinationFile = Path.Combine(destinationFolder, "testing.tmp"); ;
            var task = new CopyFileTask(source, destinationFile);

            task.Run();

            Assert.IsTrue(File.Exists(destinationFile));
        }
    }
}
