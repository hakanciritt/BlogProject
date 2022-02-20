using Core.Entities;

namespace Entities.Concrete
{
    public class Admin : IEntity
    {
        public int AdminId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
