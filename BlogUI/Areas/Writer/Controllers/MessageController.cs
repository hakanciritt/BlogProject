using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BlogUI.ControllerTypes;
using Business.Abstract;

namespace BlogUI.Areas.Writer.Controllers
{
    public class MessageController : WriterBaseController
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _messageService.GetMessageListByWriterMailAsync(CurrentUser.Mail);
            return View(result.Data);
        }
    }
}
