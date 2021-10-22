using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BlogUI.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
