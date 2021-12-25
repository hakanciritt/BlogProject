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

        public CategoryManager(ICategoryDal categoryDal , IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public IDataResult<object> Add(CategoryAddDto categoryAddDto)
        {
            var category = _mapper.Map<Category>(categoryAddDto);

            var errorList = ValidationTool.Validate(new CategoryAddValidator(), categoryAddDto);
            if (errorList != null)
            {
                return new ErrorDataResult<object>(errorList, Messages.ValidationError);
            }
            _categoryDal.Add(category);
            return new SuccessDataResult<object>(Messages.CategoryAdded);
        }

        public IResult Delete(CategoryDeleteDto categoryDeleteDto)
        {
            var category = _mapper.Map<Category>(categoryDeleteDto);

            var businessRules = BusinessRules.Run(CheckIfCategoryId(category.CategoryId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDelete);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(result);
        }

        public IDataResult<Category> GetById(int id)
        {
            var result = _categoryDal.Get(x => x.CategoryId == id);
            if (result != null)
            {
                return new SuccessDataResult<Category>(result);
            }
            return new ErrorDataResult<Category>(Messages.CategoryNotFound);
        }

        public IDataResult<object> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.CreatedDate = _categoryDal.Get(c => c.CategoryId == category.CategoryId).CreatedDate;

            var validationResult = ValidationTool.Validate(new CategoryUpdateValidator(), category);
            if (validationResult != null) return new ErrorDataResult<object>(validationResult);

            _categoryDal.Update(category);
            return new SuccessDataResult<object>(Messages.CategoryUpdated);
        }

        public IResult UpdateCategoryStatus(int categoryId)
        {
            var category = _categoryDal.Get(c => c.CategoryId == categoryId);

            if (category == null) return new ErrorResult(Messages.NotFound);

            category.UpdatedDate = DateTime.Now;
            category.Status = !category.Status;
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        private IResult CheckIfCategoryId(int categoryId)
        {
            var result = _categoryDal.Get(x => x.CategoryId == categoryId);
            if (result is null)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }
            return new SuccessResult();
        }
    }
}
