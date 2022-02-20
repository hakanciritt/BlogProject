using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Natification : IEntity
    {
        public int NatificationId { get; set; }

        public string Type { get; set; }

        public string TypeSymbol { get; set; }

        public string Details { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }
    }
}
