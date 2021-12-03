﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Blog.Dashboard.Models.Category
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
            Categories = new List<Entities.Concrete.Category>();
        }


        public List<Entities.Concrete.Category> Categories { get; set; }
    }
}
