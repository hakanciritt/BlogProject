using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using BlogUI.Areas.Writer.Models;
using BlogUI.ControllerTypes;
using Business.Abstract;

namespace BlogUI.Areas.Writer.Controllers
{

    public class DashboardController : WriterBaseController
    {
        private readonly IBlogService _blogService;

        public DashboardController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {

            var model = new DashBoardViewModel();

            model.TotalBlogCount = _blogService.GetAllAsync().Result.Data.Count;
            model.TotalBlogCountByWriter = _blogService.GetBlogListByWriterIdAsync(CurrentUser.UserId.Value).Result.Data.Count;

            return View(model);
        }
    }
}
