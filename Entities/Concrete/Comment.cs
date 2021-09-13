using Core.Entities;
using System;


namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }

        public int BlogId { get; set; }

        public string UserName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }
    }
}
