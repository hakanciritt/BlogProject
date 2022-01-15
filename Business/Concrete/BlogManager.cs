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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Extensions;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public async Task<IDataResult<object>> AddAsync(Blog blog)
        {
            var errorResult = ValidationTool.Validate(new BlogValidator(), blog);
            if (errorResult is not null)
                return new ErrorDataResult<object>(errorResult);

            blog.Status = true;
            blog.CreateDate = DateTime.Now;

            await _blogDal.AddAsync(blog);
            return new SuccessDataResult<object>(Messages.BlogAdded);
        }

        public async Task<IResult> DeleteAsync(Blog blog)
        {
            var rules = BusinessRules.Run(CheckIfBlogId(blog.BlogId));
            if (rules is not null)
            {
                return rules;
            }
            await _blogDal.DeleteAsync(blog);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Blog>>> GetAllAsync()
        {
            var result = await _blogDal.GetAllAsync();
            return new SuccessDataResult<List<Blog>>(result);
        }

        public async Task<IDataResult<Blog>> GetByIdAsync(int id)
        {
            var result = await _blogDal.GetAsync(x => x.BlogId == id);
            if (result != null)
            {
                return new SuccessDataResult<Blog>(result);
            }
            return new ErrorDataResult<Blog>(Messages.BlogNotFound);
        }

        public async Task<IDataResult<List<Blog>>> GetBlogListWithCategoryAsync()
        {
            var result = await _blogDal.GetBlogListWithCategoryAsync(x => x.Status);
            return new SuccessDataResult<List<Blog>>(result);
        }

        public async Task<IDataResult<List<Blog>>> GetAllBlogListWithCategoryAsync()
        {
            var result = await _blogDal.GetBlogListWithCategoryAsync();
            return new SuccessDataResult<List<Blog>>(result);
        }

        public async Task<IDataResult<object>> UpdateAsync(Blog blog)
        {
            var validationResult = ValidationTool.Validate(new BlogValidator(), blog);
            if (validationResult is not null)
                return new ErrorDataResult<object>(validationResult);

            var findBlog = await _blogDal.GetAsync(x => x.BlogId == blog.BlogId);
            blog.CreateDate = findBlog.CreateDate;
            blog.Status = findBlog.Status;
            blog.UpdateDate = DateTime.Now;

            await _blogDal.UpdateAsync(blog);
            return new SuccessDataResult<object>();
        }

        public async Task<IDataResult<List<Blog>>> GetBlogListByWriterIdAsync(int writerId)
        {
            var result = await _blogDal.GetAllAsync(x => x.WriterId == writerId);

            return result is not null
                ? new SuccessDataResult<List<Blog>>(result)
                : new ErrorDataResult<List<Blog>>(Messages.AuthorBlogNotFound);

        }

        public async Task<IDataResult<List<Blog>>> GetLastThreeBlogAsync()
        {
            var result = _blogDal.GetAllAsync(x => x.Status).Result.OrderBy(x => x.BlogId).Take(3).ToList();
            return new SuccessDataResult<List<Blog>>(result);
        }

        public async Task<IDataResult<List<Blog>>> GetBlogListAndCategoryByWriterIdAsync(int writerId)
        {
            return new SuccessDataResult<List<Blog>>(await _blogDal.GetBlogListWithCategoryAsync(x => x.WriterId == writerId));
        }

        public async Task<IResult> BlogStatusUpdateAsync(int blogId)
        {
            var result = await _blogDal.GetAsync(x => x.BlogId == blogId);

            if (result is null)
                return new ErrorResult(Messages.BlogNotFound);

            result.Status = result.Status ? false : true;

            await _blogDal.UpdateAsync(result);
            return new SuccessResult(Messages.BlogStatusUpdated);
        }

        private IResult CheckIfBlogId(int blogId)
        {
            if (_blogDal.GetAsync(x => x.BlogId == blogId).Result == null)
            {
                return new ErrorResult(Messages.BlogNotFound);
            }
            return null;
        }

        public async Task<IDataResult<Blog>> GetByBlogSlugNameAsync(string slugName)
        {
            return new SuccessDataResult<Blog>(await _blogDal.GetAsync(x => x.Slug == slugName));
        }
    }
}
