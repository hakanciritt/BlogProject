using System;
using System.Linq;
using BlogUI.Security;
using BlogUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogUI.ControllerTypes
{
    [Authorize]
    [Area("Writer")]
    public class WriterBaseController<TController> : Controller where TController : WriterBaseController<TController>
    {
        protected readonly ICurrentUser CurrentUser;

        public WriterBaseController()
        {
            CurrentUser = (ICurrentUser)ServiceTool.ServiceProvider.GetService(typeof(ICurrentUser));
        }
    }
}
