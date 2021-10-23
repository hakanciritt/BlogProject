using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogUI.Areas.Writer.Models;
using Business.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogUI.Areas.Writer.Controllers
{
    [Authorize]
    [Area("Writer")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }
        public IActionResult GetBlogListByWriter()
        {
            var result = _blogService.GetBlogListAndCategoryByWriterId(1);
            if (result.Success)
            {
                return View(result.Data);
            }
            TempData["Message"] = result.Message;
            return View();

        }

        public IActionResult BlogAdd()
        {
            ViewBag.Categories = (from category in _categoryService.GetAll().Data
                                    select new SelectListItem
                                    {
                                        Text = category.Name,
                                        Value = category.CategoryId.ToString()
                                    }).ToList();

            return View(new Blog());
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var result = _blogService.Add(blog);
            if (result.Success)
                return RedirectToAction("Index", "Writer");

            foreach (var error in (List<ValidationFailure>)result.Data)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(blog);
        }
    }
}
