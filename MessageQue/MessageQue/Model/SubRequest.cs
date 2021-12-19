using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQue.Model
{
    public class SubRequest
    {
        public string Name { get; set; }
        public string Topic { get; set; }

        public SubRequest(string topic)
        {
            Topic = topic;
        }

        public SubRequest()
        {

        }

        public SubRequest(string name, string topic)
        {
            Name = name;
            Topic = topic;
        }
    }
}
