using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos.Blog;

namespace Business.Abstract
{
    public interface IBlogService
    {
        Task<IDataResult<object>> AddAsync(Blog blog);
        Task<IDataResult<object>> UpdateAsync(Blog blog);
        Task<IResult> DeleteAsync(Blog blog);
        Task<IDataResult<List<BlogDto>>> GetAllAsync();
        Task<IDataResult<Blog>> GetByIdAsync(int id);
        Task<IDataResult<List<BlogDto>>> GetBlogListWithCategoryAsync();
        Task<IDataResult<List<BlogDto>>> GetAllBlogListWithCategoryAsync();
        Task<IDataResult<List<Blog>>> GetBlogListByWriterIdAsync(int writerId);
        Task<IDataResult<List<Blog>>> GetLastThreeBlogAsync();
        Task<IDataResult<List<Blog>>> GetBlogListAndCategoryByWriterIdAsync(int writerId);
        Task<IResult> BlogStatusUpdateAsync(int blogId);
        Task<IDataResult<BlogDto>> GetByBlogSlugNameAsync(string slugName);
    }
}
