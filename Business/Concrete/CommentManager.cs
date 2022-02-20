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
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public async Task<IDataResult<object>> AddAsync(Comment comment)
        {
            comment.Date = DateTime.Now;
            comment.Status = true;

            ValidationTool.Validate(new CommentValidator(), comment);

            await _commentDal.AddAsync(comment);
            return new SuccessDataResult<object>(Messages.CommentAdded);
        }

        public async Task<IResult> DeleteAsync(Comment comment)
        {
            var businessRules = BusinessRules.Run(CheckIfCommentId(comment.CommentId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            await _commentDal.DeleteAsync(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }

        public async Task<IDataResult<List<Comment>>> GetAllAsync()
        {
            var result = await _commentDal.GetAllAsync();
            return new SuccessDataResult<List<Comment>>(result);
        }

        public async Task<IDataResult<List<Comment>>> GetCommentsByBlogIdAsync(int blogId)
        {
            var result = await _commentDal.GetAllAsync(x => x.BlogId == blogId);

            return new SuccessDataResult<List<Comment>>(result);
        }

        public async Task<IDataResult<Comment>> GetByIdAsync(int id)
        {
            var result = await _commentDal.GetAsync(x => x.CommentId == id);
            if (result != null)
            {
                return new SuccessDataResult<Comment>(result);
            }
            return new ErrorDataResult<Comment>(Messages.CommentNotFound);
        }

        public async Task<IResult> UpdateAsync(Comment comment)
        {
            await _commentDal.UpdateAsync(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }

        private IResult CheckIfCommentId(int commentId)
        {
            var result = _commentDal.GetAsync(x => x.CommentId == commentId).Result;
            if (result is null)
            {
                return new ErrorResult(Messages.CommentNotFound);
            }
            return null;
        }
    }
}
