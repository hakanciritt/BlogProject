using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using Helpers.FileHelpers;
using System.IO;
using BlogUI.ControllerTypes;
using Microsoft.AspNetCore.Hosting;

namespace BlogUI.Areas.Writer.Controllers
{
    public class BlogController : WriterBaseController<BlogController>
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;

        public BlogController(IBlogService blogService, ICategoryService categoryService, IWebHostEnvironment environment)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _environment = environment;
        }
        public IActionResult GetBlogListByWriter()
        {
            var result = _blogService.GetBlogListAndCategoryByWriterId(CurrentUser.UserId);
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

            blog.WriterId = CurrentUser.UserId;
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
            if (result.Data == null)
                return NotFound();

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
            blog.WriterId = CurrentUser.UserId;
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
