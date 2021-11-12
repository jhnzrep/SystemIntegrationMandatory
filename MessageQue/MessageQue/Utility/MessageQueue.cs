using MessageQue.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQue.Utility
{
    public sealed class MessageQueue
    {
        private static MessageQueue instance = null;
        private string filepath = @"C:\Users\jcoyn\Documents\KEA\KEA - System Intergration\SystemIntegrationMandatory\MessageStorage\";
        private Dictionary<string, Queue<Message>> dic;
        private static readonly object padlock = new object();

        MessageQueue()
        {
            var loadedque = LoadMessageQue();
            if(loadedque != null) { Dic = loadedque; }
            else
            {
                Dic = new Dictionary<string, Queue<Message>>();
            }
            /*Queue<Message> que1 = new Queue<Message>();
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
            Dic.Add("Frank", que2);*/
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

        public void LoadUserMessages(string name)
        {
            foreach (var topic in SubsPersistance.Instance.Subscription.Subs)
            {
                if (!topic.Value.Contains(name)) continue;
                foreach (var file in Directory.EnumerateFiles(filepath + topic))
                {
                    Message msg = Transformer.ToObj<Message>(File.ReadAllText(file));
                    if(Dic.TryGetValue(name, out Queue<Message> value))
                    {
                        value.Enqueue(msg);
                    };
                }
            }
        }

        public void SaveMessageQue()
        {
            StorageWriter.SaveToFile<Dictionary<string,Queue<Message>>>(Dic, filepath + @"MessageQue");
        }

        public Dictionary<string, Queue<Message>> LoadMessageQue()
        {
            return StorageWriter.ReadFromFile<Dictionary<string, Queue<Message>>> (filepath + @"MessageQue");
        }

        public void AddMessage(Message msg)
        {
            if (SubsPersistance.Instance.Subscription.Subs[msg.Topic] != null)
            {
                foreach (var user in SubsPersistance.Instance.Subscription.Subs[msg.Topic])
                {
                    if (Dic.TryGetValue(user, out Queue<Message> value))
                    {
                        value.Enqueue(msg);
                    }
                    else
                    {
                        var que = new Queue<Message>();
                        que.Enqueue(msg);
                        Dic.Add(user, que);
                    }
                }
                SaveMessageQue();
            }
        }

        public Message NextMessage(string name)
        {
            if (Dic.TryGetValue(name, out Queue<Message> queue))
            {
                if (queue.TryDequeue(out Message msg))
                {
                    return msg;
                }
                else return new Message("No message in que", "No message in queue found for your name", "null");
            }
            else return new Message("No queue found", "No message queue found for your name", "null");
        }
    }
}
