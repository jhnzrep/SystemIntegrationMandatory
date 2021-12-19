using MessageQue.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQue.Utility
{
    public sealed class SubsPersistance
    {
        private Subscription subscription;
        private string filepath = @"C:\Users\jcoyn\Documents\KEA\KEA - System Intergration\SystemIntegrationMandatory\MessageStorage\Subscriptions";
        private static SubsPersistance instance = null;
        private static readonly object padlock = new object();

        SubsPersistance()
        {
            Subscription loadedsubs = StorageWriter.ReadFromFile<Subscription>(filepath);
            if (loadedsubs != null) 
            {
                subscription = loadedsubs;
                return;
            }
            subscription = new Subscription();
        }

        public static SubsPersistance Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SubsPersistance();
                    }
                    return instance;
                }
            }
        }

        public Subscription Subscription 
        { 
            get { return subscription; }
            set { subscription = value; } 
        }

        public bool AddTopic(string topic)
        {
            if(StorageWriter.AddTopic(topic))
            {
                Subscription.Subs.Add(topic, new List<string>());
                StorageWriter.SaveToFile<Subscription>(Subscription, filepath);
                return true;
            }
            return false;
        }

        public void AddSubscriber(string topic, string name)
        {
            if(Subscription.Subs.TryGetValue(topic, out List<string> list))
            {
                list.Add(name);
                StorageWriter.SaveToFile<Subscription>(Subscription, filepath);
            }
        }
    }
}
