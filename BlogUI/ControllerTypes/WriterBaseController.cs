using BlogUI.Security;
using Core.CrossCuttingConcerns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogUI.ControllerTypes
{
    [Authorize]
    [Area("Writer")]
    public class WriterBaseController : Controller
    {
        protected readonly ICurrentUser CurrentUser;

        public WriterBaseController()
        {
            CurrentUser = (ICurrentUser)ServiceTool.ServiceProvider.GetService(typeof(ICurrentUser));
        }
    }
}
