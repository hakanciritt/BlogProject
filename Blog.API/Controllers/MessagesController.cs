using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet("getmessagelistbywritermail/{email}")]
        public async Task<IActionResult> GetMessageListByWriterMailAsync(string email)
        {
            var result = await _messageService.GetMessageListByWriterMailAsync(email);
            return Ok(result.Data);
        }
    }
}
