using Microsoft.AspNetCore.Mvc;

namespace Blog.Dashboard.Components
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
