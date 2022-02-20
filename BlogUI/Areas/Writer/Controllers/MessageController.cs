using BlogUI.ApiServices;
using BlogUI.ControllerTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogUI.Areas.Writer.Controllers
{
    public class MessageController : WriterBaseController
    {
        private readonly MessageApiService _messageApiService;

        public MessageController(MessageApiService messageApiService)
        {
            _messageApiService = messageApiService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _messageApiService.GetMessageListByWriterMailAsync(CurrentUser.Mail);
            return View(result);
        }
    }
}
