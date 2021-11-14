using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Message : IEntity
    {
        public int MessageId { get; set; }

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public string Subject { get; set; }

        public string Details { get; set; }

        public DateTime Date { get; set; }

        public bool Type { get; set; }
    }
}
