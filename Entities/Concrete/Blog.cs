using Core.Entities;
using System;


namespace Entities.Concrete
{
    public class Blog : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ThumbnailImage { get; set; }

        public string Image { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Status { get; set; }
    }
}
