using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Dashboard.ControllerTypes;
using Blog.Dashboard.Models.Category;
using Dtos.Category;
using Entities.Concrete;
using FluentValidation.Results;
using WebModels.Category;

namespace Blog.Dashboard.Controllers
{
    public class CategoryController : DashboardBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var model = new CategoryListViewModel();
            model.Categories = _categoryService.GetAllAsync().Result.Data;

            return View(model);
        }

        public IActionResult AddCategory()
        {
            return View(new CategoryAddViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(CategoryAddViewModel categoryAddViewModel)
        {
            var category = _mapper.Map<CategoryAddDto>(categoryAddViewModel);
            var result = await _categoryService.AddAsync(category);

            if (result.Data is List<ValidationFailure>)
            {
                foreach (var error in (List<ValidationFailure>)result.Data)
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return View(categoryAddViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> GetCategory([FromBody] int categoryId)
        {
            var result = await _categoryService.GetByIdAsync(categoryId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdateViewModel categoryUpdateViewModel)
        {
            var category = _mapper.Map<CategoryUpdateDto>(categoryUpdateViewModel);
            var result = await _categoryService.UpdateAsync(category);
            return Ok(result);
        }

    }
}
