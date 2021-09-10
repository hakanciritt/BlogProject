using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            var result = _commentDal.GetAll();
            return new SuccessDataResult<List<Comment>>(result);
        }

        public IDataResult<Comment> GetById(int id)
        {
            var result = _commentDal.Get(x => x.Id == id);
            if (result!=null)
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
    }
}
