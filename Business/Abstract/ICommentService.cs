using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<object> Add(Comment comment);
        IResult Delete(Comment comment);
        IResult Update(Comment comment);
        IDataResult<Comment> GetById(int id);
        IDataResult<List<Comment>> GetAll();
        IDataResult<List<Comment>> GetCommentsByBlogId(int blogId);
    }
}
