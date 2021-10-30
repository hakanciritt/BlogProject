using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Writer.Models
{
    public class DashBoardViewModel
    {
        public int TotalBlogCount { get; set; }
        public int TotalBlogCountByWriter { get; set; }
    }
}
