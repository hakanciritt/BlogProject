using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BlogUI.ApiServices;
using BlogUI.ControllerTypes;
using Business.Abstract;

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
