using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogUI.ApiServices;
using Business.Abstract;

namespace BlogUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly AboutApiService _aboutApiService;

        public AboutController(AboutApiService aboutApiService)
        {
            _aboutApiService = aboutApiService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _aboutApiService.GetAllAsync();
            return View(result);
        }

        public PartialViewResult SocialMedia()
        {
            return PartialView();
        }
    }
}
