using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Blog;

namespace Blog.Dashboard.Models.Blog
{
    public class BlogListViewModel
    {
        public BlogListViewModel()
        {
            Blogs = new List<BlogDto>();
        }

        public List<BlogDto> Blogs { get; set; }
    }
}
