using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Security
{
    public interface ICurrentUser
    {
         int UserId { get; }
         string Mail { get; }
         string Name { get; }
    }
}
