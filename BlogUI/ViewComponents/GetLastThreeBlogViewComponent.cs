using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogUI.ViewComponents
{
    public class GetLastThreeBlogViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public GetLastThreeBlogViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _blogService.GetLastThreeBlogAsync();

            return View(result.Data);
        }
    }
}
