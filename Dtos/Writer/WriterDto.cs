using Dtos.Blog;
using System.Collections.Generic;

namespace Dtos.Writer
{
    public class WriterDto
    {
        public int WriterId { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public string Image { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }

        public List<BlogDto> Blogs { get; set; }
    }
}
