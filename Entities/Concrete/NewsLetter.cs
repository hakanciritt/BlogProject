using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class NewsLetter : IEntity
    {
        [Key]
        public int MailId { get; set; }

        public string Mail { get; set; }

        public bool MailStatus { get; set; }
    }
}
