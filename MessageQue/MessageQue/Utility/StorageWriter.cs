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
        public static void SaveToFile<T>(T message, string filepath)
        {
            if(!File.Exists(filepath))
            {
                using (StreamWriter sw = new StreamWriter(filepath,true))
                {
                    sw.Write(Transformer.ToJSON(message));
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(filepath))
                {
                    sw.Write(Transformer.ToJSON(message));
                }
            }
        }

        public static bool SaveToFile(Message message)
        {
            var filepath = @"C:\Users\jcoyn\Documents\KEA\KEA - System Intergration\SystemIntegrationMandatory\MessageStorage\" + message.Topic + @"\" + message.Title;
            if (File.Exists(filepath)) { return false; }
            using (StreamWriter sw = new StreamWriter(filepath, true))
            {
                sw.Write(Transformer.ToJSON(message));
            }
            return true;
        }

        public static T ReadFromFile<T>(string filepath)
        {
            if (!File.Exists(filepath)) return default;
            using (StreamReader sr = new StreamReader(filepath))
            {
                if (sr.BaseStream.Length == 0) return default;
                return Transformer.ToObj<T>(sr.ReadToEnd());
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
    }
}
