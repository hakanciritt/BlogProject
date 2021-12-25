using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos.Category;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<object> Add(CategoryAddDto categoryAddDto);
        IDataResult<object> Update(CategoryUpdateDto categoryUpdateDto);
        IResult Delete(CategoryDeleteDto categoryDeleteDto);
        IDataResult<Category> GetById(int id);
        IResult UpdateCategoryStatus(int categoryId);
        IDataResult<List<Category>> GetAll();
    }
}
