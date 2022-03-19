
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfNewsLetterDal : EfEntityRepositoryBase<NewsLetter>, INewsLetterDal
    {
        public EfNewsLetterDal(BlogContext context) : base(context)
        {
        }
    }
}
