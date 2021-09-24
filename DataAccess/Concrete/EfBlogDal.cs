using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, BlogContext>, IBlogDal
    {
        public List<Blog> GetBlogListWithCategory()
        {
            using (var context=new BlogContext())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }
    }
}
