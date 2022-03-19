
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category>, ICategoryDal
    {
        public EfCategoryDal(BlogContext context) : base(context)
        {
        }
    }
}
