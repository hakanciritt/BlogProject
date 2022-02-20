using Core.Entities;
using System;

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
