using BlogUI.Security;
using Core.CrossCuttingConcerns;
using Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        protected void AddModelError(List<ErrorDto> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
