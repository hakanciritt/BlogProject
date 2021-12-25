using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.Category
{
    public class CategoryAddViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
