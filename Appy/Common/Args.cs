using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    public class Args : Dictionary<string, string>
    {
        public new Args Add(string key, string value)
        {
            base.Add(key, value);

            return this;
        }

        public string Get(string key)
        {
            return this[key];
        }
    }
}
