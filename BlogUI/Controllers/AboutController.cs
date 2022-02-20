using BlogUI.ApiServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
