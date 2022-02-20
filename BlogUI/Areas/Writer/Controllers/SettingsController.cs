using BlogUI.Areas.Writer.Models;
using BlogUI.ControllerTypes;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogUI.Areas.Writer.Controllers
{
    public class SettingsController : WriterBaseController
    {
        private readonly IWriterService _writerService;

        public SettingsController(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new UpdatePasswordViewModel();
            var user = _writerService.GetByIdAsync(CurrentUser.UserId.Value).Result.Data;
            model.Password = user.Password;
            model.ConfirmPassword = user.Password;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePassword(UpdatePasswordViewModel updatePasswordVM)
        {

            return View("Index");
        }
    }
}
