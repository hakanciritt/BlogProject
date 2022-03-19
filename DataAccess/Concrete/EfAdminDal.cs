
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfAdminDal : EfEntityRepositoryBase<Admin>, IAdminDal
    {
        public EfAdminDal(BlogContext context) : base(context)
        {
        }
    }
}
