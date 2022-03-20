using BlogUI.ApiServices;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogApiService _blogApiService;
        public BlogController(BlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _blogApiService.GetBlogListWithCategoryAsync();
            return View(result);
        }
        public async Task<IActionResult> BlogDetails(string blogSlug)
        {
            var result = await _blogApiService.GetByBlogSlugNameAsync(blogSlug);
            return View(result);
        }
    }
}
