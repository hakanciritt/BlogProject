using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, BlogContext>, IBlogDal
    {
        public List<Blog> GetBlogListWithCategory(Expression<Func<Blog, bool>> filter = null)
        {
            using (var context = new BlogContext())
            {
                return filter == null
                    ? context.Blogs.Include(x => x.Category).ToList()
                    : context.Blogs.Include(x => x.Category).Where(filter).ToList();
            }
        }
    }
}
