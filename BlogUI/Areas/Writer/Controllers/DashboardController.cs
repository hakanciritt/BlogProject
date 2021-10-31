using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using BlogUI.Areas.Writer.Models;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using BlogUI.Security;

namespace BlogUI.Areas.Writer.Controllers
{
    [Authorize]
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICurrentUser _currentUser;

        public DashboardController(IBlogService blogService, ICurrentUser currentUser)
        {
            _blogService = blogService;
            _currentUser = currentUser;
        }
        public IActionResult Index()
        {

            var model = new DashBoardViewModel();

            model.TotalBlogCount = _blogService.GetAll().Data.Count;
            model.TotalBlogCountByWriter = _blogService.GetBlogListByWriterId(_currentUser.UserId).Data.Count;

            return View(model);
        }
    }
}
