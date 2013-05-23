using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    public class Settings : Dictionary<string, string>
    {
        public new Settings Add(string key, string value)
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
