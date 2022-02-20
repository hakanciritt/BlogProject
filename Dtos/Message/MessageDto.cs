using System;

namespace Dtos.Message
{
    public class MessageDto
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
