using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Role : IEntity
    {
        public Role()
        {
            Admins = new List<Admin>();
        }

        public int Id { get; set; }

        public string RoleName { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<Admin> Admins { get; set; }
    }
}
