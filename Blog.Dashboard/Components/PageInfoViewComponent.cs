using Microsoft.AspNetCore.Mvc;

namespace Blog.Dashboard.Components
{
    public class PageInfoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
