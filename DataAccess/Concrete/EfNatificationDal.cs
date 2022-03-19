
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfNatificationDal : EfEntityRepositoryBase<Natification>, INatificationDal
    {
        public EfNatificationDal(BlogContext context) : base(context)
        {
        }
    }
}
