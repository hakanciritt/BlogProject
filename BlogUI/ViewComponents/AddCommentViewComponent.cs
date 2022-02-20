using Microsoft.AspNetCore.Mvc;

namespace BlogUI.ViewComponents
{
    public class AddCommentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int blogId)
        {
            ViewBag.BlogId = blogId;
            return View();
        }
    }
}
