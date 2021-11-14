using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogUI.Security;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogUI.Areas.Writer.ViewComponents
{
    public class WriterMessageNatificationViewComponent : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly ICurrentUser _currentUser;

        public WriterMessageNatificationViewComponent(IMessageService messageService,ICurrentUser currentUser)
        {
            _messageService = messageService;
            _currentUser = currentUser;
        }
        public IViewComponentResult Invoke()
        {
            var result = _messageService.GetMessageListByWriterMail(_currentUser.Mail);
            return View(result.Data);
        }
    }
}
