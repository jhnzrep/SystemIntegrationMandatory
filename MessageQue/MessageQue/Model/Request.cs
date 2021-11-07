using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQue.Model
{
    public class Request
    {
        public string Title { get; set; }
        public string Type { get; set; }

        public Request()
        {

        }

        public Request(string title, string type)
        {
            Title = title;
            Type = type;
        }
    }
}
