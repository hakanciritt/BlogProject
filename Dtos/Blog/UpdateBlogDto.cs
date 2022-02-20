using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json.Serialization;

namespace Dtos.Blog
{
    public class UpdateBlogDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string Slug { get; set; }

        [JsonIgnore]
        public IFormFile ThumbnailImageFile { get; set; }

        public string ThumbnailImage { get; set; }

        [JsonIgnore]
        public IFormFile ImageFile { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
        public int WriterId { get; set; }
    }
}
