using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogUI.ViewComponents
{
    public class CommentListByBlogViewComponent : ViewComponent
    {
        ICommentService _commentService;
        public CommentListByBlogViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var data = _commentService.GetCommentsByBlogIdAsync(blogId).Result;

            return Task.FromResult<IViewComponentResult>(View(data.Data));

        }
    }
}
