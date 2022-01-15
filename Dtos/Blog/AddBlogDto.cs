using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Blog
{
    public class AddBlogDto
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public string Slug { get; set; }

        public IFormFile ThumbnailImageFile { get; set; }

        public string ThumbnailImage { get; set; }

        public IFormFile ImageFile { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
