﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<object> Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
        IDataResult<Category> GetById(int id);
        IDataResult<List<Category>> GetAll();
    }
}
