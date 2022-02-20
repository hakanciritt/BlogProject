using Core.Utilities.Results;
using Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INewsLetterService
    {
        Task<IDataResult<object>> AddNewsLetterAsync(NewsLetter newsLetter);
    }
}
