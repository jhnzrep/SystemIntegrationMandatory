using MessageQue.Model;
using MessageQue.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MessageQue.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SubsController : Controller
    {
        [HttpPost]
        [Route("subscribe")]
        public ActionResult Post([FromBody] Request request)
        {
            if(ModelState.IsValid)
            {
                if (SubsPersistance.Instance.Subscription.Subs.ContainsKey(request.Type))
                {
                    if (SubsPersistance.Instance.Subscription.Subs[request.Type].Contains(request.Name)) return BadRequest("Subscriber already exists to this topic");
                    SubsPersistance.Instance.AddSubscriber(request.Type, request.Name);
                    if (MessageQueue.Instance.Dic.ContainsKey(request.Name)) 
                    {
                        MessageQueue.Instance.Dic.Add(request.Name, new Queue<Message>());
                    }
                    return Ok("Successfully subscribed.");
                }
                return BadRequest("Topic does not exist");
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("addtopic")]
        public ActionResult Post([FromBody] SubRequest topic)
        {
            if(ModelState.IsValid)
            {
                if (SubsPersistance.Instance.AddTopic(topic.Type))
                {
                    return Ok("Sucessfully added topic");
                }
                return BadRequest("Topic already exists");
            }
            return BadRequest();
        }
    }
}
