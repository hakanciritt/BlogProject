using Microsoft.AspNetCore.Mvc;

namespace Blog.Dashboard.Components
{
    public class HeaderNavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
