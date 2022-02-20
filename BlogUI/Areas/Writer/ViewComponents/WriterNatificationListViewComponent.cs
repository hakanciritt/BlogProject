using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogUI.Areas.Writer.ViewComponents
{
    public class WriterNatificationListViewComponent : ViewComponent
    {
        private readonly INatificationService _natificationService;

        public WriterNatificationListViewComponent(INatificationService natificationService)
        {
            _natificationService = natificationService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _natificationService.GetAllAsync();

            return View(result.Data);
        }
    }
}
