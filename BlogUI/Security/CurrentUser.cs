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
        public string UserId
        {
            get
            {
                return _context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
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
    }
}
