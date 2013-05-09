﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy.Core
{
    public class Header
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public Header(string name = "", string value = "")
        {
            Name = name;

            Value = value;
        }
    }
}
