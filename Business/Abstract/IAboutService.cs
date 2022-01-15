using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        Task<IDataResult<object>> AddAsync(About about);
        Task<IResult> UpdateAsync(About about);
        Task<IResult> DeleteAsync(About about);
        Task<IDataResult<About>> GetByIdAsync(int id);
        Task<IDataResult<List<About>>> GetAllAsync();

    }
}
