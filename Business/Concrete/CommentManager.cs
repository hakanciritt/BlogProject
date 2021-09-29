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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IDataResult<object> Add(Comment comment)
        {
            var validationResult = ValidationTool.Validate(new CommentValidator(), comment);
            if (validationResult is not null)
            {
                return new ErrorDataResult<object>(validationResult);
            }
            _commentDal.Add(comment);
            return new SuccessDataResult<object>(Messages.CommentAdded);
        }

        public IResult Delete(Comment comment)
        {
            var businessRules = BusinessRules.Run(CheckIfCommentId(comment.CommentId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            var result = _commentDal.GetAll();
            return new SuccessDataResult<List<Comment>>(result);
        }

        public IDataResult<List<Comment>> GetCommentsByBlogId(int blogId)
        {
            var result = _commentDal.GetAll(x => x.BlogId == blogId);
            
            return new SuccessDataResult<List<Comment>>(result);
        }

        public IDataResult<Comment> GetById(int id)
        {
            var result = _commentDal.Get(x => x.CommentId == id);
            if (result != null)
            {
                return new SuccessDataResult<Comment>(result);
            }
            return new ErrorDataResult<Comment>(Messages.CommentNotFound);
        }

        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }
        private IResult CheckIfCommentId(int commentId)
        {
            var result = _commentDal.Get(x => x.CommentId == commentId);
            if (result is null)
            {
                return new ErrorResult(Messages.CommentNotFound);
            }
            return null;
        }
    }
}
