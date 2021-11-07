using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQue.Model
{
    public class Message
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public Message()
        {

        }

        public Message(string title, string body)
        {
            Body = body;
            Title = title;
        }
    }
}
