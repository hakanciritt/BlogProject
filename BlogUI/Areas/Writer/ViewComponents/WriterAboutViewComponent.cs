﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogUI.Security;
using Business.Abstract;

namespace BlogUI.Areas.Writer.ViewComponents
{
    public class WriterAboutViewComponent : ViewComponent
    {
        private readonly IWriterService _writerService;
        private readonly ICurrentUser _currentUser;

        public WriterAboutViewComponent(IWriterService writerService , ICurrentUser currentUser)
        {
            _writerService = writerService;
            _currentUser = currentUser;
        }
        public IViewComponentResult Invoke()
        {
            var result = _writerService.GetById(_currentUser.UserId);
            return View(result.Data);
        }
    }
}