using Microsoft.AspNetCore.Mvc;

namespace Blog.Dashboard.Controllers
{
    public class WidgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
