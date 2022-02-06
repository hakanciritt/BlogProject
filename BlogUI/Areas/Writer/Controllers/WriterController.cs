﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using BlogUI.ApiServices;
using BlogUI.ControllerTypes;
using Business.Abstract;
using Business.Mapping;
using Microsoft.AspNetCore.Hosting;
using Core.Utilities.Helpers;
using Dtos.Writer;
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
            return View(ObjectMapper.Mapper.Map<WriterProfileUpdateViewModel>(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(WriterProfileUpdateViewModel writerVM)
        {
            var writer = ObjectMapper.Mapper.Map<WriterUpdateDto>(writerVM);

            if (writerVM.File is not null)
                writer.Image = FileHelper.Save(_environment.WebRootPath + "\\images\\" + writerVM.File.FileName, writerVM.File);

            var result = await _writerService.UpdateAsync(writer);

            if (result.Success)
            {
                return RedirectToAction("EditProfile");
            }
            return View(writerVM);
        }

    }
}
