using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Dashboard.ControllerTypes;

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
