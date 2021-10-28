using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = _blogService.GetBlogListAndCategoryByWriterId(int.Parse(userId));
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
        public JsonResult StatusUpdate(int blogId)
        {
            var result = _blogService.BlogStatusUpdate(blogId);

            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {

            string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId != blog.WriterId.ToString())
                ModelState.AddModelError("WriterId", "Lütfen bu kısmı değiştirmeyiniz");

            var result = _blogService.Add(blog);

            if (result.Success)
                return RedirectToAction("Index", "Writer");

            foreach (var error in (List<ValidationFailure>)result.Data)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            ViewBag.Categories = (from category in _categoryService.GetAll().Data
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.CategoryId.ToString()
                                  }).ToList();
            return View(blog);
        }


        public IActionResult EditBlog([FromRoute] int blogId)
        {
            var result = _blogService.GetById(blogId);
            ViewBag.Categories = (from category in _categoryService.GetAll().Data
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.CategoryId.ToString()
                                  }).ToList();
            return View(result.Data);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var result = _blogService.Update(blog);
            if (result.Success)
            {
                return Redirect("/yazar/bloglar");
            }
            else
            {
                if (result.Data is List<ValidationFailure>)
                {
                    foreach (var error in (List<ValidationFailure>)result.Data)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }

                    return View(blog);
                }

            }
            return View();
        }
    }
}
