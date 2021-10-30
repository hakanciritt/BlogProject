using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BlogUI.Areas.Writer.Models;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace BlogUI.Areas.Writer.Controllers
{
    [Authorize]
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly IBlogService _blogService;

        public DashboardController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = new DashBoardViewModel();

            model.TotalBlogCount = _blogService.GetAll().Data.Count;
            model.TotalBlogCountByWriter = _blogService.GetBlogListByWriterId(int.Parse(userId)).Data.Count;

            return View(model);
        }
    }
}
