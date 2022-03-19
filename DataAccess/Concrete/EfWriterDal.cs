
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfWriterDal : EfEntityRepositoryBase<Writer>, IWriterDal
    {
        public EfWriterDal(BlogContext context) : base(context)
        {
        }
    }
}
