
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfRoleDal : EfEntityRepositoryBase<Role>, IRoleDal
    {
        public EfRoleDal(BlogContext context) : base(context)
        {
        }
    }
}
