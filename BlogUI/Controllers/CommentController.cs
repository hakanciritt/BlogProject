using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace BlogUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

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


        [HttpPost]
        public JsonResult AddComment(Comment comment)
        {
            var result = _commentService.Add(comment);
            if (!result.Success)
            {
                return Json(result);
            }

            return Json(result);
        }
    }
}
