using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult Index()
        {
            var result = _messageService.GetMessageListByWriterMail(CurrentUser.Mail);
            return View(result.Data);
        }
    }
}
