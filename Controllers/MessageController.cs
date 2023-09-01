using BASITWEBAPI.Controllers;
using BASITWEBAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BASITWEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : Controller
    {
        static List<Message> messages = new List<Message>{
        new Message{Id=1, MessageValue="Hello"},
        new Message{Id=2, MessageValue="World"}
    };

        [HttpGet]
        public List<Message> Get()
        {
            return messages;
        }

        [HttpPost]
        public Message Post(Message message)
        {
            messages.Add(message);
            return message;
        }

        [HttpDelete]
        public Message Delete(Message message)
        {
            messages.Remove(message);
            return message;
        }
    }






}