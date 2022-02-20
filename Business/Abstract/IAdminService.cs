using Core.Utilities.Results;
using Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        Task<IDataResult<Admin>> GetByIdAsync(int id);

    }
}
