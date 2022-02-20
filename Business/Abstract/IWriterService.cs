using Core.Utilities.Results;
using Dtos.Writer;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

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
