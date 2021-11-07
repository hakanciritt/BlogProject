using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogUI.Areas.Writer.Models;
using BlogUI.Security;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Entities.Concrete;
using Helpers.FileHelpers;
using Microsoft.AspNetCore.Hosting;

namespace BlogUI.Areas.Writer.Controllers
{
    [Authorize]
    [Area("Writer")]
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly ICurrentUser _currentUser;
        private readonly IWebHostEnvironment _environment;

        public WriterController(IWriterService writerService, ICurrentUser currentUser, IWebHostEnvironment environment)
        {
            _writerService = writerService;
            _currentUser = currentUser;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            var model = new WriterProfileUpdateViewModel();
            var result = _writerService.GetById(_currentUser.UserId).Data;
            model.Name = result.Name;
            model.Mail = result.Mail;
            model.Password = result.Password;
            model.About = result.About;
            model.Image = result.Image;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProfile(WriterProfileUpdateViewModel writerVM)
        {
            var writer = new Entities.Concrete.Writer()
            {
                WriterId = _currentUser.UserId,
                About = writerVM.About,
                Mail = writerVM.Mail,
                Name = writerVM.Name,
                Status = true,
                Password = writerVM.Password,
            };
            if (writerVM.Password.Trim() != writerVM.PasswordConfirm.Trim())
                ModelState.AddModelError("PasswordConfirm", "Şifre ve Şifre tekrar aynı olmak zorundadır");

            if (writerVM.File is not null)
                writer.Image = FileHelper.Save(_environment.WebRootPath + "\\images\\" + writerVM.File.FileName, writerVM.File);

            var result = _writerService.Update(writer);
            if (result.Success)
            {
                return RedirectToAction("EditProfile");
            }
            return View(writerVM);
        }

    }
}
