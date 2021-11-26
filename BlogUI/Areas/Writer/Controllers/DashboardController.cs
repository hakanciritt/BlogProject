using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        public IActionResult Index()
        {

            var model = new DashBoardViewModel();

            model.TotalBlogCount = _blogService.GetAll().Data.Count;
            model.TotalBlogCountByWriter = _blogService.GetBlogListByWriterId(CurrentUser.UserId).Data.Count;

            return View(model);
        }
    }
}
