using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogUI.Areas.Writer.ViewComponents
{
    public class WriterNatificationListViewComponent : ViewComponent
    {
        private readonly INatificationService _natificationService;

        public WriterNatificationListViewComponent(INatificationService natificationService)
        {
            _natificationService = natificationService;
        }
        public IViewComponentResult Invoke()
        {
            var result = _natificationService.GetAll();

            return View(result.Data);
        }
    }
}
