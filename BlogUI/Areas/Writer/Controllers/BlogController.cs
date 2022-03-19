using BlogUI.ApiServices;
using BlogUI.ControllerTypes;
using Business.Abstract;
using Core.Utilities.Helpers;
using Dtos.Blog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Writer.Controllers
{
    public class BlogController : WriterBaseController
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;
        private readonly BlogApiService _blogApiService;

        public BlogController(IBlogService blogService, ICategoryService categoryService, IWebHostEnvironment environment, BlogApiService blogApiService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _environment = environment;
            _blogApiService = blogApiService;
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
            ViewBag.Categories = new SelectList((await _categoryService.GetAllAsync()).Data, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> StatusUpdate(int blogId)
        {
            var result = await _blogService.BlogStatusUpdateAsync(blogId);

            return new JsonResult(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BlogAdd(AddBlogDto blog)
        {
            ViewBag.Categories = new SelectList((await _categoryService.GetAllAsync()).Data, "CategoryId", "Name");
            var blogImage = Request.Form.Files["blogImage"];

            if (blogImage is not null)
                blog.Image = FileHelper.Save(_environment.WebRootPath + "\\images\\" + blogImage.FileName, blogImage);

            blog.WriterId = CurrentUser.UserId.Value;

            var result = await _blogApiService.AddAsync(blog);

            if (result.IsSuccess)
                return RedirectToAction("GetBlogListByWriter", "Blog", new { area = "Writer" });
            else
            {
                if (!string.IsNullOrEmpty(result.ErrorMessage))
                {
                    TempData["ErrorMessage"] = result.ErrorMessage;
                }

                if (result.Errors != null)
                    AddModelError(result.Errors);

                return View(blog);
            }
        }

        public async Task<IActionResult> EditBlog([FromRoute] int blogId)
        {
            var result = await _blogApiService.GetByIdAsync(blogId);
            if (result.Data == null)
                return NotFound();

            ViewBag.Categories = new SelectList((await _categoryService.GetAllAsync()).Data, "CategoryId", "Name");
            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBlog(BlogDto blog)
        {
            blog.WriterId = CurrentUser.UserId.Value;

            var result = await _blogApiService.UpdateAsync(blog);

            if (result.IsSuccess)
            {
                return Redirect("/yazar/bloglar");
            }
            else
            {
                if (!string.IsNullOrEmpty(result.ErrorMessage))
                {
                    TempData["ErrorMessage"] = result.ErrorMessage;
                }

                if (result.Errors.Any())
                {
                    AddModelError(result.Errors);
                }
                return View(blog);
            }
        }
    }
}
