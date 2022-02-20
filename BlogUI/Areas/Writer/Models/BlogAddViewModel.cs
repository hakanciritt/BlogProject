using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BlogUI.Areas.Writer.Models
{
    public class BlogAddViewModel
    {
        public Blog Blog { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
