using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        Task<IDataResult<object>> AddAsync(Contact contact);
        Task<IResult> DeleteAsync(Contact contact);
        Task<IResult> UpdateAsync(Contact contact);
        Task<IDataResult<Contact>> GetByIdAsync(int id);
        Task<IDataResult<List<Contact>>> GetAllAsync();
    }
}
