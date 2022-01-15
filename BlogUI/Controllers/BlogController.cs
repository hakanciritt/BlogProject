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
        public async Task<IActionResult> Index()
        {
            var result = await _blogService.GetBlogListWithCategoryAsync();
            TempData["Status"] = result.Success;
            if (result.Success)
            {
                return View(result.Data);
            }

            TempData["Message"] = result.Message;
            return View();
        }
        public async Task<IActionResult> BlogDetails(string blogSlug)
        {
            var result = await _blogService.GetByBlogSlugNameAsync(blogSlug);
            if (result.Data == null)
                return NotFound();

            if (result.Success)
            {
                return View(result.Data);
            }
            TempData["Message"] = result.Message;
            return View();
        }
    }
}
