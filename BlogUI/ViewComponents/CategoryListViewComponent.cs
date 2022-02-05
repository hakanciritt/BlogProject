﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogUI.Models.Category;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public CategoryListViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public  Task<IViewComponentResult> InvokeAsync()
        {
            var result =  _blogService.GetBlogListWithCategoryAsync().Result;
            var data = result.Data.GroupBy(c => c.Category.Name).Select(x => new CategoryCountViewModel { Key = x.Key, Count = x.Count() }).ToList();

            return Task.FromResult<IViewComponentResult>(View(data));
        }
    }
}
