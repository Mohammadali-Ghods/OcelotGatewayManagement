using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public class SwaggerConfig
    {
        public SwaggerConfig(string name, string version, string url)
        {
            Name = name;
            Version = version;
            Url = url;
        }

        public string Name { get; private set; }
        public string Version { get; private set; }
        public string Url { get; private set; }
    }
}
