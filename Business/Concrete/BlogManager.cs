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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
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

            blog.Status = true;
            blog.CreateDate = DateTime.Now;
            _blogDal.Add(blog);
            return new SuccessDataResult<object>(Messages.BlogAdded);
        }

        public IResult Delete(Blog blog)
        {
            var rules = BusinessRules.Run(CheckIfBlogId(blog.BlogId));
            if (rules is not null)
            {
                return rules;
            }
            _blogDal.Delete(blog);
            return new SuccessResult();
        }

        public IDataResult<List<Blog>> GetAll()
        {
            var result = _blogDal.GetAll();
            return new SuccessDataResult<List<Blog>>(result);
        }

        public IDataResult<Blog> GetById(int id)
        {
            var result = _blogDal.Get(x => x.BlogId == id);
            if (result != null)
            {
                return new SuccessDataResult<Blog>(result);
            }
            return new ErrorDataResult<Blog>(Messages.BlogNotFound);
        }

        public IDataResult<List<Blog>> GetBlogListWithCategory()
        {
            var result = _blogDal.GetBlogListWithCategory(x => x.Status);
            return new SuccessDataResult<List<Blog>>(result);
        }

        public IDataResult<object> Update(Blog blog)
        {
            var validationResult = ValidationTool.Validate(new BlogValidator(), blog);
            if (validationResult is not null)
                return new ErrorDataResult<object>(validationResult);

            var findBlog = _blogDal.Get(x => x.BlogId == blog.BlogId);
            blog.CreateDate = findBlog.CreateDate;
            blog.Status = findBlog.Status;

            _blogDal.Update(blog);
            return new SuccessDataResult<object>();
        }

        public IDataResult<List<Blog>> GetBlogListByWriterId(int writerId)
        {
            var result = _blogDal.GetAll(x => x.WriterId == writerId);

            return result is not null
                ? new SuccessDataResult<List<Blog>>(result)
                : new ErrorDataResult<List<Blog>>(Messages.AuthorBlogNotFound);

        }

        public IDataResult<List<Blog>> GetLastThreeBlog()
        {
            var result = _blogDal.GetAll(x => x.Status).OrderBy(x => x.BlogId).Take(3).ToList();
            return new SuccessDataResult<List<Blog>>(result);
        }

        public IDataResult<List<Blog>> GetBlogListAndCategoryByWriterId(int writerId)
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetBlogListWithCategory(x => x.WriterId == writerId));
        }

        public IResult BlogStatusUpdate(int blogId)
        {
            var result = _blogDal.Get(x => x.BlogId == blogId);

            if (result is null)
                return new ErrorResult(Messages.BlogNotFound);

            result.Status = result.Status ? false : true;

            _blogDal.Update(result);
            return new SuccessResult();
        }

        private IResult CheckIfBlogId(int blogId)
        {
            if (_blogDal.Get(x => x.BlogId == blogId) == null)
            {
                return new ErrorResult(Messages.BlogNotFound);
            }
            return null;
        }
    }
}
