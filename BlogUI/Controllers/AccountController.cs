using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BlogUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWriterService _writerService;

        public AccountController(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Writer writer)
        {
            var result = _writerService.GetByWriterEmail(writer.Mail);
            if (result.Success)
            {
                return RedirectToAction("", "");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
