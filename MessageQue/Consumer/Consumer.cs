using MessageQue.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    class Consumer
    {
        const string URL = "http://localhost:29924/Message/search";

        public Consumer()
        {
        }

        public async Task<string> GetMessage(Request request)
        {
            using(HttpClient client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync<Request>(URL, request);
                var json = response.Content.ReadAsStringAsync().Result;
                //Message msg = JsonConvert.DeserializeObject<Message>(json);
                return json;
            }
        }
    }
}
