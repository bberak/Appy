using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Appy.Core
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
    }
}
