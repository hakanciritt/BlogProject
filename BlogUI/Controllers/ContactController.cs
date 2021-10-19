﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using FluentValidation.Results;

namespace BlogUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            return View(new Contact());
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.Date = DateTime.Now;
            contact.Status = true;
            var result = _contactService.Add(contact);
            if (!result.Success)
            {
                foreach (var error in (List<ValidationFailure>)result.Data)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(contact);
            }

            return View();
        }
    }
}