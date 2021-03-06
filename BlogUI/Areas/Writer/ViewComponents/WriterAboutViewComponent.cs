using BlogUI.Security;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogUI.Areas.Writer.ViewComponents
{
    public class WriterAboutViewComponent : ViewComponent
    {
        private readonly IWriterService _writerService;
        private readonly ICurrentUser _currentUser;

        public WriterAboutViewComponent(IWriterService writerService, ICurrentUser currentUser)
        {
            _writerService = writerService;
            _currentUser = currentUser;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _writerService.GetByIdAsync(_currentUser.UserId.Value);
            return View(result.Data);
        }
    }
}
