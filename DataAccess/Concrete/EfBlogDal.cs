using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, BlogContext>, IBlogDal
    {
        public async Task<List<Blog>> GetBlogListWithCategoryAsync(Expression<Func<Blog, bool>> filter = null)
        {
            using (var context = new BlogContext())
            {
                return filter == null
                    ? await context.Blogs.Include(x => x.Category).ToListAsync()
                    : await context.Blogs.Include(x => x.Category).Where(filter).ToListAsync();
            }
        }
        public async Task<List<Blog>> GetBlogListWriterAndCommentAsync(Expression<Func<Blog, bool>> filter = null)
        {
            using (var context = new BlogContext())
            {
                return filter == null
                    ? await context.Blogs.Include(x => x.Writer).Include(x => x.Comments).ToListAsync()
                    : await context.Blogs.Include(x => x.Writer).Include(x => x.Comments).Where(filter).ToListAsync();
            }
        }
    }
}
