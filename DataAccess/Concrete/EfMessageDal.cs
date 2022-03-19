
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfMessageDal : EfEntityRepositoryBase<Message>, IMessageDal
    {
        public EfMessageDal(BlogContext context) : base(context)
        {
        }
    }
}
