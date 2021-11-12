using MessageQue.Model;
using MessageQue.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MessageQue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : Controller
    {
        /*[HttpPost]
        [Route("search")]
        public ActionResult Post([FromBody] Request request)
        {
            if (ModelState.IsValid)
            {
                var filepath = @"C:\Users\jcoyn\Documents\KEA\KEA - System Intergration\SystemIntegrationMandatory\MessageStorage\" + request.Title + ".txt";
                if (System.IO.File.Exists(filepath))
                {
                    Message message = new Message(request.Title, StorageWriter.ReadFromFile(filepath));
                    string serialized;

                    switch (request.Type)
                    {
                        case "XML":
                            serialized = Transformer.MessageToXml(message);
                            break;
                        case "JSON":
                            serialized = Transformer.MessageToJSON(message);
                            break;
                        default:
                            return BadRequest();
                    }
                    return Ok(serialized);
                }
                return BadRequest();
            }
            return BadRequest();
        }*/

        [HttpPost]
        [Route("next")]
        public ActionResult Post([FromBody] Request request)
        {
            if (ModelState.IsValid) 
            {
                Message message = MessageQueue.Instance.NextMessage(request.Name);
                string serialized;
                if (message == null) { return Ok("No more messages in que"); }
                switch (request.Type)
                {
                    case "XML":
                        serialized = Transformer.ToXml(message);
                        break;
                    case "JSON":
                        serialized = Transformer.ToJSON(message);
                        break;
                    default:
                        return BadRequest("Invalid request type");
                }
                return Ok(serialized);
            }
            return BadRequest("Invalid request");
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Post([FromBody] Message message)
        {
            if (ModelState.IsValid)
            {
                if(StorageWriter.SaveToFile(message))
                {
                    MessageQueue.Instance.AddMessage(message);
                    return Ok();
                }
                return BadRequest();
            }
            else { return BadRequest(); }
        }
    }
}
