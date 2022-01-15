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
        Task<IDataResult<object>> AddAsync(CategoryAddDto categoryAddDto);
        Task<IDataResult<object>> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        Task<IResult> DeleteAsync(CategoryDeleteDto categoryDeleteDto);
        Task<IDataResult<Category>> GetByIdAsync(int id);
        Task<IResult> UpdateCategoryStatusAsync(int categoryId);
        Task<IDataResult<List<Category>>> GetAllAsync();
    }
}
