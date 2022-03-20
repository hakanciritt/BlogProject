using System.Linq;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BlogUI.ApiServices;

namespace BlogUI.ViewComponents
{
    public class GetLastThreeBlogViewComponent : ViewComponent
    {
        private readonly BlogApiService _blogApiService;

        public GetLastThreeBlogViewComponent(BlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = (await _blogApiService.GetBlogListWithCategoryAsync()).OrderByDescending(d => d.CreateDate.Date).Take(3).ToList();

            return View(result);
        }
    }
}
