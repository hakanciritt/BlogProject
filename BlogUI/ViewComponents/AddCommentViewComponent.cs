using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
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
