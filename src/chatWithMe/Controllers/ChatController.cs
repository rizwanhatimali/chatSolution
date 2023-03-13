using chatWithMe.Models;
using chatWithMe.Processors;
using Microsoft.AspNetCore.Mvc;

namespace chatWithMe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {       
        private readonly ILogger<ChatController> _logger;

        public ChatController(ILogger<ChatController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "askYourQuestion")]
        public IActionResult AskYourQuestion([FromBody] ChatInput input)
        {
            var response = ChatGPT.GetMyAnswer(input);
            return Ok(new ChatOutput { Answer = response });
        }
    }
}