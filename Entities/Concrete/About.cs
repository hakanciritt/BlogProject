using Core.Entities;
using System;


namespace Entities.Concrete
{
    public class About : IEntity
    {
        public int AboutId { get; set; }

        public string Details1 { get; set; }

        public string Details2 { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string MapLocation { get; set; }

        public bool Status { get; set; }
    }
}
