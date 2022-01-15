using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogUI.Security;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IViewComponentResult> Invoke()
        {
            var result = await _blogService.GetBlogListByWriterIdAsync(int.Parse(_currentUser.UserId.ToString()));
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }
    }
}
