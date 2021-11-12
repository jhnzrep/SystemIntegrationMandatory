using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MessageQue.Model;

namespace MessageQue
{
    public class Transformer
    {
        public static string ToXml<T>(T message)
        {
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(message.GetType());
                serializer.Serialize(stringwriter, message);
                return stringwriter.ToString();
            }
        }

        public static string ToJSON<T>(T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }
        
        public static T ToObj<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
