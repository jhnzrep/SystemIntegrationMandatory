using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQue
{
    public class Message
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }

        public Message()
        {

        }

        public Message(string body, string type, string title)
        {
            Type = type;
            Body = body;
            Title = title;
        }
    }
}
