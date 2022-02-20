using BlogUI.Security;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogUI.Areas.Writer.ViewComponents
{
    public class WriterMessageNatificationViewComponent : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly ICurrentUser _currentUser;

        public WriterMessageNatificationViewComponent(IMessageService messageService, ICurrentUser currentUser)
        {
            _messageService = messageService;
            _currentUser = currentUser;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _messageService.GetMessageListByWriterMailAsync(_currentUser.Mail);
            return View(result.Data);
        }
    }
}
