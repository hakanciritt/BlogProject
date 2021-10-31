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

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<object> Add(Category category)
        {
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

        public IResult Update(Category category)
        {
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
