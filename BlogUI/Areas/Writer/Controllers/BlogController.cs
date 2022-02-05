using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;
using BlogUI.ControllerTypes;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace BlogUI.Areas.Writer.Controllers
{
    public class BlogController : WriterBaseController
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
        public async Task<IActionResult> GetBlogListByWriter()
        {
            var result = await _blogService.GetBlogListAndCategoryByWriterIdAsync(CurrentUser.UserId.Value);
            if (result.Success)
            {
                return View(result.Data);
            }
            TempData["Message"] = result.Message;
            return View();

        }

        public async Task<IActionResult> BlogAdd()
        {
            ViewBag.Categories = (from category in _categoryService.GetAllAsync().Result.Data
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.CategoryId.ToString()
                                  }).ToList();

            return View(new Blog());
        }
        [HttpPost]
        public async Task<JsonResult> StatusUpdate(int blogId)
        {
            var result = await _blogService.BlogStatusUpdateAsync(blogId);

            return new JsonResult(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BlogAdd(Blog blog)
        {
            ViewBag.Categories = (from category in _categoryService.GetAllAsync().Result.Data
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.CategoryId.ToString()
                                  }).ToList();

            var blogImage = Request.Form.Files["blogImage"];

            if (blogImage is not null)
                blog.Image = FileHelper.Save(_environment.WebRootPath + "\\images\\" + blogImage.FileName, blogImage);

            blog.WriterId = CurrentUser.UserId.Value;
            var result = await _blogService.AddAsync(blog);

            if (result.Success)
                return RedirectToAction("GetBlogListByWriter", "Blog", new { area = "Writer" });

            foreach (var error in (List<ValidationFailure>)result.Data)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(blog);
        }


        public async Task<IActionResult> EditBlog([FromRoute] int blogId)
        {
            var result = await _blogService.GetByIdAsync(blogId);
            if (result.Data == null)
                return NotFound();

            ViewBag.Categories = (from category in _categoryService.GetAllAsync().Result.Data
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.CategoryId.ToString()
                                  }).ToList();
            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBlog(Blog blog)
        {
            blog.WriterId = CurrentUser.UserId.Value;
            var result = await _blogService.UpdateAsync(blog);
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
