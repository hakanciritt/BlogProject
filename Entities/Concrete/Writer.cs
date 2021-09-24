using Core.Entities;
using System;


namespace Entities.Concrete
{
    public class Writer : IEntity
    {
        public int WriterId { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public string Image { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }
    }
}
