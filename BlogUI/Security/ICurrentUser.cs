using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Security
{
    public interface ICurrentUser
    {
         string UserId { get; }
         string Mail { get; }
         string Name { get; }
    }
}
