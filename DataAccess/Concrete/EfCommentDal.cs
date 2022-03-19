
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment>, ICommentDal
    {
        public EfCommentDal(BlogContext context) : base(context)
        {
        }
    }
}
