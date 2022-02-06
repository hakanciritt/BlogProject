using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos.Writer;

namespace Business.Abstract
{
    public interface IWriterService
    {
        Task<IDataResult<object>> AddAsync(WriterAddDto writer);
        Task<IResult> DeleteAsync(Writer writer);
        Task<IResult> UpdateAsync(WriterUpdateDto writer);
        Task<IDataResult<Writer>> GetByIdAsync(int id);
        Task<IDataResult<List<Writer>>> GetAllAsync();
        Task<IDataResult<Writer>> GetByWriterEmailAsync(string email);
        Task<IDataResult<object>> UserLoginAsync(Writer writer);
    }
}
