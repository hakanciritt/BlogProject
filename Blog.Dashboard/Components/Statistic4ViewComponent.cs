using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Dashboard.Components
{
    public class Statistic4ViewComponent : ViewComponent
    {
        private readonly IAdminService _adminService;

        public Statistic4ViewComponent(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
