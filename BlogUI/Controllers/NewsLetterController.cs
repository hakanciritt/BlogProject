using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace BlogUI.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService _newsLetterService;

        public NewsLetterController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService;
        }

        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> SubscribeMail(NewsLetter newsLetter)
        {
            var result = await _newsLetterService.AddNewsLetterAsync(newsLetter);
            return Json(result);
        }
    }
}
