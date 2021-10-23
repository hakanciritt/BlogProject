using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogUI.Areas.Writer.Models
{
    public class BlogAddViewModel
    {
        public Blog Blog { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
