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
        public static void SaveToFile(Message message)
        {
            var filepath = @"C:\Users\jcoyn\Documents\KEA\KEA - System Intergration\SystemIntegrationMandatory\MessageStorage\" + message.Title + ".txt";
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
    }
}
