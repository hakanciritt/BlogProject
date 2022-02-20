using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface INewsLetterDal : IEntityRepository<NewsLetter>
    {
    }
}
