using Dtos.Blog;
using System.Collections.Generic;

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
