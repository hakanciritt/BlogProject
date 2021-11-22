using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BlogUI.Security
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _context;
        public CurrentUser(IHttpContextAccessor context)
        {
            _context = context;
        }
        public int UserId
        {
            get
            {
                return int.Parse(_context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            }
        }

        public string Mail
        {
            get
            {
                return _context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            }
        }

        public string Name
        {
            get
            {
                return _context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            }
        }

        public string[] Roles
        {
            get
            {
                return _context.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToArray();
            }
        }
    }
}
