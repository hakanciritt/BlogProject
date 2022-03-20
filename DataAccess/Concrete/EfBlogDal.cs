using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog>, IBlogDal
    {
        public EfBlogDal(BlogContext context) : base(context)
        {
        }

        public async Task<List<Blog>> GetBlogListWithCategoryAsync(Expression<Func<Blog, bool>> filter = null)
        {
            return filter == null
                    ? await _context.Blogs.Include(x => x.Category).ToListAsync()
                    : await _context.Blogs.Include(x => x.Category).Where(filter).ToListAsync();
        }
        public async Task<List<Blog>> GetBlogListWriterAndCommentAsync(Expression<Func<Blog, bool>> filter = null)
        {
            return filter == null
                    ? await _context.Blogs.Include(x => x.Writer).Include(x => x.Comments).ToListAsync()
                    : await _context.Blogs.Include(x => x.Writer).Include(x => x.Comments).Where(filter).ToListAsync();
        }
    }
}
