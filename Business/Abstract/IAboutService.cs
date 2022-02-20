using Core.Utilities.Results;
using Dtos.About;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        Task<IDataResult<object>> AddAsync(About about);
        Task<IResult> UpdateAsync(About about);
        Task<IResult> DeleteAsync(About about);
        Task<IDataResult<About>> GetByIdAsync(int id);
        Task<IDataResult<List<AboutDto>>> GetAllAsync();

    }
}
