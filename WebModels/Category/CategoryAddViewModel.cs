using System;

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
