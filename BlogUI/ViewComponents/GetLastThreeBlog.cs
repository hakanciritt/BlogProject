using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogUI.ViewComponents
{
    public class GetLastThreeBlog : ViewComponent
    {
        private readonly IBlogService _blogService;

        public GetLastThreeBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var result = _blogService.GetLastThreeBlog();

            return View(result.Data);
        }
    }
}
