
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfContactDal : EfEntityRepositoryBase<Contact>, IContactDal
    {
        public EfContactDal(BlogContext context) : base(context)
        {
        }
    }
}
