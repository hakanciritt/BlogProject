using Core.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Entities.Concrete
{
    public class Blog : IEntity
    {
        public int BlogId { get; set; }

        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }

        public string Slug { get; set; }

        public string ThumbnailImage { get; set; }

        public string Image { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool Status { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int WriterId { get; set; }

        public Writer Writer { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
