using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MessageQue.Model;

namespace MessageQue.Utility
{
    public class StorageWriter
    {
        public static void SaveToFile(Message message, string topic)
        {
            var filepath = @"C:\Users\jcoyn\Documents\KEA\KEA - System Intergration\SystemIntegrationMandatory\MessageStorage\" + topic;
            if (!Directory.Exists(filepath)) { Directory.CreateDirectory(filepath); }
            filepath = filepath + @"\" + message.Title;
            using (StreamWriter sw = new StreamWriter(filepath, true))
            {
                sw.WriteLine(message.Body);
            }
        }

        public static string ReadFromFile(string filepath)
        {
            using (StreamReader sr = new StreamReader(filepath))
            {
                return sr.ReadToEnd();
            }
        }

        public static void SaveSubs()
        {
            var filepath = @"C:\Users\jcoyn\Documents\KEA\KEA - System Intergration\SystemIntegrationMandatory\MessageStorage\Subscribers";
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                sw.Write(Transformer.SubsToJSON(SubsPersistance.Instance.Subscription));
            }
        }

        public static Subscription LoadSubs()
        {
            var filepath = @"C:\Users\jcoyn\Documents\KEA\KEA - System Intergration\SystemIntegrationMandatory\MessageStorage\Subscribers";
            using (StreamReader sr = new StreamReader(filepath))
            {
                if (sr.BaseStream.Length == 0) return null;
                return Transformer.JSONToSubs(sr.ReadToEnd());
            }
        }

        public static bool AddTopic(string topic)
        {
            var filepath = @"C:\Users\jcoyn\Documents\KEA\KEA - System Intergration\SystemIntegrationMandatory\MessageStorage\" + topic;
            if (!Directory.Exists(filepath)) 
            { 
                Directory.CreateDirectory(filepath);
                return true;
            }
            return false;
        }

       /* public static bool SaveTopics()
        {

        }*/
    }
}
