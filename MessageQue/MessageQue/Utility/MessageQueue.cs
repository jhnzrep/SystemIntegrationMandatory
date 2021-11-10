using MessageQue.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQue.Utility
{
    public sealed class MessageQueue
    {
        private static MessageQueue instance = null;
        private Dictionary<string, Queue<Message>> dic;
        private static readonly object padlock = new object();

        MessageQueue()
        {
            Dic = new Dictionary<string, Queue<Message>>();
            Queue<Message> que1 = new Queue<Message>();
            que1.Enqueue(new Message("Test1", "John1"));
            que1.Enqueue(new Message("Test2", "John2"));
            que1.Enqueue(new Message("Test3", "John3"));
            que1.Enqueue(new Message("Test4", "John4"));
            que1.Enqueue(new Message("Test5", "John5"));
            que1.Enqueue(new Message("Test6", "John6"));
            que1.Enqueue(new Message("Test7", "John7"));
            que1.Enqueue(new Message("Test8", "John8"));

            Queue<Message> que2 = new Queue<Message>();
            que2.Enqueue(new Message("Test1", "Frank1"));
            que2.Enqueue(new Message("Test2", "Frank2"));
            que2.Enqueue(new Message("Test3", "Frank3"));
            que2.Enqueue(new Message("Test4", "Frank4"));
            que2.Enqueue(new Message("Test5", "Frank5"));
            que2.Enqueue(new Message("Test6", "Frank6"));
            que2.Enqueue(new Message("Test7", "Frank7"));
            que2.Enqueue(new Message("Test8", "Frank8"));

            Dic.Add("John", que1);
            Dic.Add("Frank", que2);
        }

        public static MessageQueue Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new MessageQueue();
                        }
                    }
                }
                return instance;
            }
        }

        public Dictionary<string , Queue<Message>> Dic
        {
            get { return dic; }
            set { dic = value; }
        }


        public Message NextMessage(string name)
        {
            if (Dic.TryGetValue(name, out Queue<Message> queue))
            {
                if (queue.TryDequeue(out Message msg))
                {
                    return msg;
                }
                else return new Message("No message in que", "No message in queue found for your name");
            }
            else return new Message("No queue found", "No message queue found for your name");
        }
    }
}
