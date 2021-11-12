using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogUI.Security;
using Helpers.FileHelpers;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BlogUI.Areas.Writer.Controllers
{
    [Authorize]
    [Area("Writer")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly ICurrentUser _currentUser;
        private readonly IWebHostEnvironment _environment;

        public BlogController(IBlogService blogService, ICategoryService categoryService, ICurrentUser currentUser, IWebHostEnvironment environment)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _currentUser = currentUser;
            _environment = environment;
        }
        public IActionResult GetBlogListByWriter()
        {
            var result = _blogService.GetBlogListAndCategoryByWriterId(_currentUser.UserId);
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
        [ValidateAntiForgeryToken]
        public IActionResult BlogAdd(Blog blog)
        {
            ViewBag.Categories = (from category in _categoryService.GetAll().Data
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.CategoryId.ToString()
                                  }).ToList();

            var blogImage = Request.Form.Files["blogImage"];

            if(blogImage is not null) 
                blog.Image = FileHelper.Save(_environment.WebRootPath + "\\images\\" + blogImage.FileName, blogImage);

            blog.WriterId = _currentUser.UserId;
            var result = _blogService.Add(blog);

            if (result.Success)
                return RedirectToAction("GetBlogListByWriter", "Blog", new { area = "Writer" });

            foreach (var error in (List<ValidationFailure>)result.Data)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

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
        [ValidateAntiForgeryToken]
        public IActionResult EditBlog(Blog blog)
        {
            blog.WriterId = _currentUser.UserId;
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
