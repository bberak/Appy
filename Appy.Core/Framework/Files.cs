using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Appy.Core
{
    public static class Files
    {
        public static string[] FindAll(string startDir, string pattern)
        {
            string[] files = Directory.GetFiles(startDir, pattern, SearchOption.AllDirectories);

            if (files.Length == 0)
                throw new FileNotFoundException("Could not find any files with the pattern: " + pattern);

            return files;
        }

        public static string[] FindAll(string pattern)
        {
            return FindAll(Environment.CurrentDirectory, pattern);
        }

        public static string FindFirst(string startDir, string pattern)
        {
            return FindAll(startDir, pattern)[0];
        }

        public static string FindFirst(string pattern)
        {
            return FindAll(Environment.CurrentDirectory, pattern)[0];
        }

        public static string FindView(string viewName)
        {
            string pattern = @"Site\Views\" + viewName;

            return FindFirst(pattern);
        }

        public static string ReadView(string viewName)
        {
            string viewPath = FindView(viewName);

            return File.ReadAllText(viewPath);
        }

        public static bool Exists(string file)
        {
            return File.Exists(file);
        }
    }
}
