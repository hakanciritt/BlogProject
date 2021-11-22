using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using BlogUI.ControllerTypes;

namespace BlogUI.Areas.Writer.Controllers
{
    public class SettingsController : WriterBaseController<SettingsController>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
