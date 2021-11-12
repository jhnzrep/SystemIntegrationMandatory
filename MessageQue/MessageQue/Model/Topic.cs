using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQue.Model
{
    public class Topic
    {
        public Topic()
        {

        }

        public Topic(string topic)
        {
            this.topic = topic;
        }

        public string topic { get; set; }


    }
}
