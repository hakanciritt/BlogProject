using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using DataAccess.Concrete;

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
            return View(new Writer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Writer writer)
        {
            var result = _writerService.UserLogin(writer);
            if (result.Success)
            {
                BlogContext context = new BlogContext();
                var user = context.Writers.FirstOrDefault(x => x.Mail == writer.Mail && x.Password == writer.Password);
                if(user is not null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.WriterId.ToString()),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Mail),
                        //new Claim(ClaimTypes.NameIdentifier, writer.WriterId.ToString())
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    return RedirectToAction("Index", "Dashboard", new { area = "Writer" });
                }
            }
            else
            {
                foreach (var error in (List<ValidationFailure>)result.Data)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(writer);
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
