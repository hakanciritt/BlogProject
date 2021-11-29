using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Dashboard.Models.Category;
using Entities.Concrete;
using FluentValidation.Results;

namespace Blog.Dashboard.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var model = new CategoryListViewModel();
            model.Categories = _categoryService.GetAll().Data;

            return View(model);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Data is List<ValidationFailure>)
            {
                return BadRequest(result.Data);
            }

            return Ok();
        }
    }
}
