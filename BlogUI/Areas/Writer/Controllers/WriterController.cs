using BlogUI.ApiServices;
using BlogUI.ControllerTypes;
using Business.Abstract;
using Business.Mapping;
using Core.Utilities.Helpers;
using Dtos.Writer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebModels.Writer;

namespace BlogUI.Areas.Writer.Controllers
{
    public class WriterController : WriterBaseController
    {
        private readonly IWriterService _writerService;
        private readonly WriterApiService _writerApiService;
        private readonly IWebHostEnvironment _environment;

        public WriterController(IWriterService writerService, WriterApiService writerApiService, IWebHostEnvironment environment)
        {
            _writerService = writerService;
            _writerApiService = writerApiService;
            _environment = environment;
        }

        public async Task<IActionResult> EditProfile()
        {
            var result = await _writerApiService.GetByIdAsync(CurrentUser.UserId.Value);
            var model = ObjectMapper.Mapper.Map<WriterProfileUpdateViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(WriterProfileUpdateViewModel writerViewModel)
        {
            var model = writerViewModel;
            var writer = ObjectMapper.Mapper.Map<WriterUpdateDto>(model);
            writer.WriterId = CurrentUser.UserId.Value;

            if (model.File is not null)
                writer.Image = FileHelper.Save(_environment.WebRootPath + "\\images\\" + model.File.FileName, model.File);

            var result = await _writerApiService.UpdateAsync(writer);

            if (result.IsSuccess)
            {
                return RedirectToAction("EditProfile", model);
            }
            else
            {
                if (!string.IsNullOrEmpty(result.ErrorMessage))
                {
                    TempData["ErrorMessage"] = result.ErrorMessage;
                }

                if (result.Errors.Any())
                {
                    AddModelError(result.Errors);
                }

                return View(model);
            }
        }
    }
}
