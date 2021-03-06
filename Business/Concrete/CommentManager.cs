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
using DataAccess.UnitOfWorks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IUnitOfWork _unitOfWork;

        public CommentManager(ICommentDal commentDal, IUnitOfWork unitOfWork)
        {
            _commentDal = commentDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<object>> AddAsync(Comment comment)
        {
            comment.Date = DateTime.Now;
            comment.Status = true;

            await ValidationTool.ValidateAsync(new CommentValidator(), comment);

            await _commentDal.AddAsync(comment);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<object>(Messages.CommentAdded);
        }

        public async Task<IResult> DeleteAsync(Comment comment)
        {
            var businessRules = BusinessRules.Run(CheckIfCommentId(comment.CommentId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            _commentDal.Delete(comment);
            await _unitOfWork.CommitAsync();
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
            _commentDal.Update(comment);
            await _unitOfWork.CommitAsync();
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
