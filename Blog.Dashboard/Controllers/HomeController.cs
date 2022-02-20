using Blog.Dashboard.ControllerTypes;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Dashboard.Controllers
{
    public class HomeController : DashboardBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
