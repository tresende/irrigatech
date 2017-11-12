using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        [HttpPost]
        public ChatParameters Post([FromBody]ChatParameters chatParameters)
        {
            ConversationService conversation = new ConversationService();
            return conversation.StartConversation(chatParameters.Text, chatParameters.Context);
        }
    }
}
