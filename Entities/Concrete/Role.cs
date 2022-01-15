using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

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
