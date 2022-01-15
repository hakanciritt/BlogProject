using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

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
