using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogUI.Models.Register;
using Entities.Concrete;
using FluentValidation.Results;

namespace BlogUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IWriterService _writerService;

        public RegisterController(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public IActionResult Index()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterViewModel registerAddVM)
        {
            Writer writer = new Writer()
            {
                Name = registerAddVM.Name,
                Mail = registerAddVM.Mail,
                Password = registerAddVM.Password,
                Status = true,
            };

            var result = await _writerService.AddAsync(writer);
            if (result.Success)
                return RedirectToAction(actionName: "Index", "Register");

            if (!result.Success)
            {
                if (result.Data is List<ValidationFailure>)
                {
                    foreach (var error in (List<ValidationFailure>)result.Data)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }

                    return View(registerAddVM);
                }
            }
            return View();
        }
    }
}
