using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<object> Add(Category category)
        {
            category.CreatedDate = DateTime.Now;
            
            var errorList = ValidationTool.Validate(new CategoryValidator(), category);
            if (errorList != null)
            {
                return new ErrorDataResult<object>(errorList, Messages.ValidationError);
            }
            _categoryDal.Add(category);
            return new SuccessDataResult<object>(Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
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

        public IDataResult<object> Update(Category category)
        {
            category.UpdatedDate = DateTime.Now;
            category.CreatedDate = _categoryDal.Get(c => c.CategoryId == category.CategoryId).CreatedDate;

            var validationResult = ValidationTool.Validate(new CategoryValidator(), category);
            if (validationResult != null) return new ErrorDataResult<object>(validationResult);

            _categoryDal.Update(category);
            return new SuccessDataResult<object>(Messages.CategoryUpdated);
        }

        public IResult UpdateCategoryStatus(int categoryId)
        {
            var category = _categoryDal.Get(c => c.CategoryId == categoryId);

            if (category == null) return new ErrorResult(Messages.NotFound);

            category.UpdatedDate = DateTime.Now;
            category.Status = category.Status ? false : true;
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
