﻿using Microsoft.AspNetCore.Mvc;

namespace Blog.Dashboard.Components
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
