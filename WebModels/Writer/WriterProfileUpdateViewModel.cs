using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.Writer
{
    public class WriterProfileUpdateViewModel
    {
        public string Name { get; set; }

        public string About { get; set; }

        public string Image { get; set; }

        public string Mail { get; set; }

        public IFormFile File { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}
