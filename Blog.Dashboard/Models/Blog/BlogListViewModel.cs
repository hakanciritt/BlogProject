using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Dashboard.Models.Blog
{
    public class BlogListViewModel
    {
        public BlogListViewModel()
        {
            Blogs = new List<Entities.Concrete.Blog>();
        }

        public List<Entities.Concrete.Blog> Blogs { get; set; }
    }
}
