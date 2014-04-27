using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Appy.Core.Framework
{
    public static class Dirs
    {
        public static string GetCleanPath(string source, string replacement = "")
        {
            foreach (var forbiddenChar in Path.GetInvalidPathChars())
            {
                source = source.Replace(forbiddenChar.ToString(), replacement);
            }

            return source;
        }

        public static string Combine(params string[] cleanPaths)
        {
            return Path.Combine(cleanPaths);
        }

        public static string CleanAndCombine(params string[] unsafePaths)
        {
            List<string> cleanPaths = new List<string>();
            unsafePaths.ToList().ForEach(p => cleanPaths.Add(GetCleanPath(p)));

            return Combine(cleanPaths.ToArray());
        }

        public static void Copy(string sourceDir, string destinationDir)
        {
            Copy(new DirectoryInfo(sourceDir), new DirectoryInfo(destinationDir));
        }

        public static void Copy(DirectoryInfo source, DirectoryInfo destination)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                Copy(dir, destination.CreateSubdirectory(dir.Name));

            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(destination.FullName, file.Name));
        }
    }
}
