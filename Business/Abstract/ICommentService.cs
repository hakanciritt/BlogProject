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
        Task<IDataResult<object>> AddAsync(Comment comment);
        Task<IResult> DeleteAsync(Comment comment);
        Task<IResult> UpdateAsync(Comment comment);
        Task<IDataResult<Comment>> GetByIdAsync(int id);
        Task<IDataResult<List<Comment>>> GetAllAsync();
        Task<IDataResult<List<Comment>>> GetCommentsByBlogIdAsync(int blogId);
    }
}
