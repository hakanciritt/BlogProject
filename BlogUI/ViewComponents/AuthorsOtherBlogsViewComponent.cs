using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogUI.ViewComponents
{
    public class AuthorsOtherBlogsViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public AuthorsOtherBlogsViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var result = _blogService.GetBlogListByWriterId(1);
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }
    }
}
