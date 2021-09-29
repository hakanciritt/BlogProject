using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;

namespace BlogUI.ViewComponents
{
    public class CommentListByBlogViewComponent : ViewComponent
    {
        ICommentService _commentService;
        public CommentListByBlogViewComponent( ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke(int blogId)
        {
            var data = _commentService.GetCommentsByBlogId(blogId);

            return View(data.Data);

        }
    }
}
