using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQue.Model
{
    public class SubRequest
    {
        public SubRequest()
        {

        }

        public SubRequest(string name, string topic)
        {
            this.Name = name;
            this.Topic = topic;
        }

        public string Name { get; set; }
        public string Topic { get; set; }

    }
}
