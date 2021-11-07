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
        public static string MessageToXml(Message message)
        {
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(message.GetType());
                serializer.Serialize(stringwriter, message);
                return stringwriter.ToString();
            }
        }

        public static string MessageToJSON(Message message)
        {
            string jsonstring = JsonSerializer.Serialize<Message>(message);
            return jsonstring;
        }
    }
}
