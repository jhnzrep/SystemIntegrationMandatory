using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MessageQue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : Controller
    {
        [HttpGet]
        /*public Message Get([FromBody] string title, string type)
        {
            
        }*/

        [HttpPost]
        public ActionResult Post([FromBody] Message message)
        {
            var filepath = @"C:\Users\jcoyn\Documents\KEA\KEA - System Intergration\SystemIntegrationMandatory\MessageStorage\" + message.Title + ".txt";

            if (ModelState.IsValid)
            {
                using (StreamWriter sw = new StreamWriter(filepath, true))
                {
                    sw.WriteLine(message.Title);
                    sw.WriteLine(message.Type);
                    sw.WriteLine(message.Body);
                }
                return Ok();
            }
            else { return BadRequest(); }
        }
    }
}
