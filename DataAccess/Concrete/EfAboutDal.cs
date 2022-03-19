
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfAboutDal : EfEntityRepositoryBase<About>, IAboutDal
    {

        public EfAboutDal(BlogContext context) : base(context)
        {
        }
    }
}
