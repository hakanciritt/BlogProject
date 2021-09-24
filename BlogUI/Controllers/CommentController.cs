﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult CommentListForBlog()
        {
            return PartialView();
        }

        public PartialViewResult AddComment()
        {
            return PartialView();
        }
    }
}
