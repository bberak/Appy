using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Appy.Compile.Tests
{
    [TestClass]
    public class CompileTaskTests
    {
        string BaseTestFolder = @"C:\CompileTaskTests";
        string SourceFolder = @"C:\CompileTaskTests\Source";
        string DestinationFolder = @"C:\CompileTaskTests\Destination";
        string FileName = "copy_me.tmp";

        [TestInitialize]
        public void Setup()
        {
            Directory.CreateDirectory(SourceFolder);
            File.Create(Path.Combine(SourceFolder, FileName)).Dispose();
            Directory.CreateDirectory(DestinationFolder);
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (Directory.Exists(BaseTestFolder))
                Directory.Delete(BaseTestFolder, true);
        }

        [TestMethod]
        public void Verify_CopyFolderTask_ContentsAreCopied()
        {
            var task = new CopyFolderTask(SourceFolder, DestinationFolder);

            task.Run();

            Assert.IsTrue(File.Exists(Path.Combine(DestinationFolder, FileName)));
        }
    }
}
