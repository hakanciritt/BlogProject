using System;

namespace WebModels.Category
{
    public class CategoryUpdateViewModel
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
