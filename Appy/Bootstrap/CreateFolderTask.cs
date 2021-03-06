﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Appy.Core;

namespace Appy
{
    public class CreateFolderTask : ITask
    {
        string NewPath;

        public CreateFolderTask(string newPath)
        {
            NewPath = newPath;
        }

        public void Run()
        {
            if (Directory.Exists(NewPath))
                throw new Exception("The directory {0} already exists. Cannot create a new project here.".F(NewPath));

            Directory.CreateDirectory(NewPath);
        }
    }
}
