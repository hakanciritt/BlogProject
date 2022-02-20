using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogUI.Areas.Writer.ViewComponents
{
    public class WriterBlogListViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public WriterBlogListViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _blogService.GetBlogListWithCategoryAsync();
            return View(result.Data);
        }
    }
}
