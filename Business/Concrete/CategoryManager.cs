using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.CategoryValidation;
using Core.Business;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Dtos.Category;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Mapping;
using DataAccess.UnitOfWork;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(ICategoryDal categoryDal , IUnitOfWork unitOfWork)
        {
            _categoryDal = categoryDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<object>> AddAsync(CategoryAddDto categoryAddDto)
        {
            var category = ObjectMapper.Mapper.Map<Category>(categoryAddDto);
            await ValidationTool.ValidateAsync(new CategoryAddValidator(), categoryAddDto);

            await _categoryDal.AddAsync(category);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<object>(Messages.CategoryAdded);
        }

        public async Task<IResult> DeleteAsync(CategoryDeleteDto categoryDeleteDto)
        {
            var category = ObjectMapper.Mapper.Map<Category>(categoryDeleteDto);

            var businessRules = BusinessRules.Run(CheckIfCategoryId(category.CategoryId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            _categoryDal.Delete(category);
            await _unitOfWork.CommitAsync();
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
            var category = ObjectMapper.Mapper.Map<Category>(categoryUpdateDto);
            category.CreatedDate = _categoryDal.GetAsync(c => c.CategoryId == category.CategoryId).Result.CreatedDate;

            await ValidationTool.ValidateAsync(new CategoryUpdateValidator(), category);


            _categoryDal.Update(category);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<object>(Messages.CategoryUpdated);
        }

        public async Task<IResult> UpdateCategoryStatusAsync(int categoryId)
        {
            var category = await _categoryDal.GetAsync(c => c.CategoryId == categoryId);

            if (category == null) return new ErrorResult(Messages.NotFound);

            category.UpdatedDate = DateTime.Now;
            category.Status = !category.Status;
            _categoryDal.Update(category);
            await _unitOfWork.CommitAsync();
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
