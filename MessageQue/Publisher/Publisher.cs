using MessageQue.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Publisher
{
    class Publisher
    {
        const string URL = "http://localhost:29924/Message/add";

        public Publisher()
        {
        }

        public async Task<HttpResponseMessage> PostRequest(Message message)
        {
            using(HttpClient client = new HttpClient())
            {
                //var json = JsonConvert.SerializeObject(message);
                // StringContent = new StringContent(json);
                var response = await client.PostAsJsonAsync<Message>(URL, message);
                return response;
            }
        }
    }
}
