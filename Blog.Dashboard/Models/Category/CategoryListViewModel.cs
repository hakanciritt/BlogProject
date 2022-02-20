using System.Collections.Generic;

namespace Blog.Dashboard.Models.Category
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
            Categories = new List<Entities.Concrete.Category>();
        }


        public List<Entities.Concrete.Category> Categories { get; set; }
    }
}
