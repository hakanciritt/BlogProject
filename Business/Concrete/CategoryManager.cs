using Business.Abstract;
using Business.Constants;
using Core.Business;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Business.ValidationRules.FluentValidation.CategoryValidation;
using Dtos.Category;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<object>> AddAsync(CategoryAddDto categoryAddDto)
        {
            var category = _mapper.Map<Category>(categoryAddDto);

            var errorList = ValidationTool.Validate(new CategoryAddValidator(), categoryAddDto);
            if (errorList != null)
            {
                return new ErrorDataResult<object>(errorList, Messages.ValidationError);
            }
            await _categoryDal.AddAsync(category);
            return new SuccessDataResult<object>(Messages.CategoryAdded);
        }

        public async Task<IResult> DeleteAsync(CategoryDeleteDto categoryDeleteDto)
        {
            var category = _mapper.Map<Category>(categoryDeleteDto);

            var businessRules = BusinessRules.Run(CheckIfCategoryId(category.CategoryId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            await _categoryDal.DeleteAsync(category);
            return new SuccessResult(Messages.CategoryDelete);
        }

        public async Task<IDataResult<List<Category>>> GetAllAsync()
        {
            var result = await _categoryDal.GetAllAsync();
            return new SuccessDataResult<List<Category>>(result);
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            var result = await _categoryDal.GetAsync(x => x.CategoryId == id);
            if (result != null)
            {
                return new SuccessDataResult<Category>(result);
            }
            return new ErrorDataResult<Category>(Messages.CategoryNotFound);
        }

        public async Task<IDataResult<object>> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.CreatedDate = _categoryDal.GetAsync(c => c.CategoryId == category.CategoryId).Result.CreatedDate;

            var validationResult = ValidationTool.Validate(new CategoryUpdateValidator(), category);
            if (validationResult != null) return new ErrorDataResult<object>(validationResult);

            await _categoryDal.UpdateAsync(category);
            return new SuccessDataResult<object>(Messages.CategoryUpdated);
        }

        public async Task<IResult> UpdateCategoryStatusAsync(int categoryId)
        {
            var category = await _categoryDal.GetAsync(c => c.CategoryId == categoryId);

            if (category == null) return new ErrorResult(Messages.NotFound);

            category.UpdatedDate = DateTime.Now;
            category.Status = !category.Status;
            await _categoryDal.UpdateAsync(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        private IResult CheckIfCategoryId(int categoryId)
        {
            var result = _categoryDal.GetAsync(x => x.CategoryId == categoryId).Result;
            if (result is null)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }
            return new SuccessResult();
        }
    }
}
