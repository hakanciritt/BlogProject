using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    interface ICommentService
    {
        IDataResult<object> Add(Comment comment);
        IResult Delete(Comment comment);
        IResult Update(Comment comment);
        IDataResult<Comment> GetById(int id);
        IDataResult<List<Comment>> GetAll();
    }
}
