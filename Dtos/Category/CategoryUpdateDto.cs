using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Category
{
    public class CategoryUpdateDto
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
