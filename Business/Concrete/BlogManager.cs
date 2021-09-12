﻿using Business.Abstract;
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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public IDataResult<object> Add(Blog blog)
        {
            var errorResult = ValidationTool.Validate(new BlogValidator(), blog);
            if (errorResult is not null)
            {
                return new ErrorDataResult<object>(errorResult);
            }
            _blogDal.Add(blog);
            return new SuccessDataResult<object>(Messages.BlogAdded);
        }

        public IResult Delete(Blog blog)
        {
            var rules = BusinessRules.Run(CheckIfBlogId(blog.Id));
            if (rules is not null)
            {
                return rules;
            }
            _blogDal.Delete(blog);
            return new SuccessResult();
        }

        public IDataResult<Blog> GetById(int id)
        {
            var result = _blogDal.Get(x => x.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Blog>(result);
            }
            return new ErrorDataResult<Blog>(Messages.BlogNotFound);
        }

        public IResult Update(Blog blog)
        {
            _blogDal.Update(blog);
            return new SuccessResult();
        }
        private IResult CheckIfBlogId(int blogId)
        {
            if (_blogDal.Get(x => x.Id == blogId) == null)
            {
                return new ErrorResult(Messages.BlogNotFound);
            }
            return null;
        }
    }
}
