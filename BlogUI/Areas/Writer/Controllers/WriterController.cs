﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BlogUI.Areas.Writer.Controllers
{
    [Authorize]
    [Area("Writer")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}