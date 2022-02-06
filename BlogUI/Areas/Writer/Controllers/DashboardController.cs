using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using BlogUI.ApiServices;
using BlogUI.Areas.Writer.Models;
using BlogUI.ControllerTypes;
using Business.Abstract;

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
            model.TotalBlogCount = (await _blogApiService.GetAllAsync()).Count;
            model.TotalBlogCountByWriter = (await _blogApiService.GetBlogListByWriterIdAsync(CurrentUser.UserId.Value)).Count;

            return View(model);
        }
    }
}
