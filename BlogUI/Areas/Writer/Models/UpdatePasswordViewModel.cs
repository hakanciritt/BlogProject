using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Writer.Models
{
    public class UpdatePasswordViewModel
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
