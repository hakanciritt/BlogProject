using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            var result = _blogService.GetBlogListWithCategory();
            TempData["Status"] = result.Success;
            if (result.Success)
            {
                return View(result.Data);
            }

            TempData["Message"] = result.Message;
            return View();
        }
        public IActionResult BlogDetails(string blogSlug)
        {
            var result = _blogService.GetByBlogSlugName(blogSlug);
            if (result.Success)
            {
                return View(result.Data);
            }
            TempData["Message"] = result.Message;
            return View();
        }
    }
}
