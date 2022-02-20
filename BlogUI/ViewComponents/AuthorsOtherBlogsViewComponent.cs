using BlogUI.Security;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogUI.ViewComponents
{
    public class AuthorsOtherBlogsViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly ICurrentUser _currentUser;

        public AuthorsOtherBlogsViewComponent(IBlogService blogService, ICurrentUser currentUser)
        {
            _blogService = blogService;
            _currentUser = currentUser;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            var result = _blogService.GetBlogListByWriterIdAsync(int.Parse(_currentUser.UserId.ToString())).Result;
            return Task.FromResult<IViewComponentResult>(View(result.Data));
        }
    }
}
