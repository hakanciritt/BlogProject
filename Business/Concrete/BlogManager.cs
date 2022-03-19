using Business.Abstract;
using Business.Constants;
using Business.CustomErrors;
using Business.Mapping;
using Business.ValidationRules.FluentValidation;
using Core.Business;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Dtos.Blog;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.UnitOfWork;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        private readonly IUnitOfWork _unitOfWork;

        public BlogManager(IBlogDal blogDal, IUnitOfWork unitOfWork)
        {
            _blogDal = blogDal;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<AddBlogDto>> AddAsync(AddBlogDto blog)
        {
            await ValidationTool.ValidateAsync(new BlogValidator(), blog);

            var result = ObjectMapper.Mapper.Map<Blog>(blog);
            result.Status = true;
            result.CreateDate = DateTime.Now;

            await _blogDal.AddAsync(result);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<AddBlogDto>(blog, Messages.BlogAdded);
        }

        public async Task<IResult> DeleteAsync(Blog blog)
        {
            var rules = BusinessRules.Run(CheckIfBlogId(blog.BlogId));
            if (rules is not null)
            {
                return rules;
            }
            _blogDal.Delete(blog);
            await _unitOfWork.CommitAsync();
            return new SuccessResult();
        }

        public async Task<IDataResult<List<BlogDto>>> GetAllAsync()
        {
            var result = await _blogDal.GetAllAsync();
            return new SuccessDataResult<List<BlogDto>>(ObjectMapper.Mapper.Map<List<BlogDto>>(result));
        }

        public async Task<IDataResult<BlogDto>> GetByIdAsync(int id)
        {
            var result = ObjectMapper.Mapper.Map<BlogDto>(await _blogDal.GetAsync(x => x.BlogId == id));

            if (result != null)
            {
                return new SuccessDataResult<BlogDto>(result);
            }
            return new ErrorDataResult<BlogDto>(Messages.BlogNotFound);
        }

        public async Task<IDataResult<List<BlogDto>>> GetBlogListWithCategoryAsync()
        {
            var result = await _blogDal.GetBlogListWithCategoryAsync(x => x.Status);
            return new SuccessDataResult<List<BlogDto>>(ObjectMapper.Mapper.Map<List<BlogDto>>(result));
        }

        public async Task<IDataResult<List<BlogDto>>> GetAllBlogListWithCategoryAsync()
        {
            var result = await _blogDal.GetBlogListWithCategoryAsync();
            return new SuccessDataResult<List<BlogDto>>(ObjectMapper.Mapper.Map<List<BlogDto>>(result));
        }

        public async Task<IDataResult<BlogDto>> UpdateAsync(BlogDto blogDto)
        {
            await ValidationTool.ValidateAsync(new BlogValidator(), blogDto);
            var result = ObjectMapper.Mapper.Map<Blog>(blogDto);

            var findBlog = await _blogDal.GetAsync(x => x.BlogId == blogDto.BlogId);
            blogDto.CreateDate = findBlog.CreateDate;
            blogDto.Status = findBlog.Status;
            blogDto.UpdateDate = DateTime.Now;

            _blogDal.Update(result);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<BlogDto>(blogDto);
        }

        public async Task<IDataResult<List<BlogDto>>> GetBlogListByWriterIdAsync(int writerId)
        {
            var result = await _blogDal.GetAllAsync(x => x.WriterId == writerId);
            return result is not null
                ? new SuccessDataResult<List<BlogDto>>(ObjectMapper.Mapper.Map<List<BlogDto>>(result))
                : new ErrorDataResult<List<BlogDto>>(Messages.AuthorBlogNotFound);
        }

        public async Task<IDataResult<List<Blog>>> GetLastThreeBlogAsync()
        {
            var result = _blogDal.GetAllAsync(x => x.Status).Result.OrderBy(x => x.BlogId).Take(3).ToList();
            return new SuccessDataResult<List<Blog>>(result);
        }

        public async Task<IDataResult<List<BlogDto>>> GetBlogListAndCategoryByWriterIdAsync(int writerId)
        {
            var result = await _blogDal.GetBlogListWithCategoryAsync(x => x.WriterId == writerId);
            return new SuccessDataResult<List<BlogDto>>(ObjectMapper.Mapper.Map<List<BlogDto>>(result));
        }

        public async Task<IResult> BlogStatusUpdateAsync(int blogId)
        {
            var result = await _blogDal.GetAsync(x => x.BlogId == blogId);

            if (result is null)
                return new ErrorResult(Messages.BlogNotFound);

            result.Status = result.Status ? false : true;

            _blogDal.Update(result);
            await _unitOfWork.CommitAsync();
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

        public async Task<IDataResult<BlogDto>> GetByBlogSlugNameAsync(string slugName)
        {
            var result = await _blogDal.GetAsync(x => x.Slug == slugName);
            return new SuccessDataResult<BlogDto>(ObjectMapper.Mapper.Map<BlogDto>(result));
        }
    }
}
