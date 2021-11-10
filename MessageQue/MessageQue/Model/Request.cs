using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQue.Model
{
    public class Request
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Request()
        {

        }

        public Request(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}
