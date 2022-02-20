using BlogUI.ApiServices;
using BlogUI.Areas.Writer.Models;
using BlogUI.ControllerTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogUI.Areas.Writer.Controllers
{

    public class DashboardController : WriterBaseController
    {
        private readonly BlogApiService _blogApiService;

        public DashboardController(BlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new DashBoardViewModel();
            var blogTotalCount = await _blogApiService.GetAllAsync();
            model.TotalBlogCount = blogTotalCount.Count;
            var totalBlogCountByWriter = await _blogApiService.GetBlogListByWriterIdAsync(CurrentUser.UserId.Value);
            model.TotalBlogCountByWriter = totalBlogCountByWriter.Count;

            return View(model);
        }
    }
}
