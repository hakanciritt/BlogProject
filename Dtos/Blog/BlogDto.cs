using Dtos.Category;
using System;

namespace Dtos.Blog
{
    public class BlogDto
    {
        public int BlogId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Slug { get; set; }

        public string ThumbnailImage { get; set; }

        public string Image { get; set; }

        public int WriteId { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }
        public int WriterId { get; set; }

        public CategoryDto Category { get; set; }

    }
}
