using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogUI.Security
{
    public interface ICurrentUser
    {
        int UserId { get; }
        string Mail { get; }
        string Name { get; }
        string[] Roles { get; }
    }
}
