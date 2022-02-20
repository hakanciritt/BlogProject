using Core.Utilities.Results;
using Dtos.Blog;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        Task<IDataResult<AddBlogDto>> AddAsync(AddBlogDto blog);
        Task<IDataResult<BlogDto>> UpdateAsync(BlogDto blogDto);
        Task<IResult> DeleteAsync(Blog blog);
        Task<IDataResult<List<BlogDto>>> GetAllAsync();
        Task<IDataResult<BlogDto>> GetByIdAsync(int id);
        Task<IDataResult<List<BlogDto>>> GetBlogListWithCategoryAsync();
        Task<IDataResult<List<BlogDto>>> GetAllBlogListWithCategoryAsync();
        Task<IDataResult<List<BlogDto>>> GetBlogListByWriterIdAsync(int writerId);
        Task<IDataResult<List<Blog>>> GetLastThreeBlogAsync();
        Task<IDataResult<List<BlogDto>>> GetBlogListAndCategoryByWriterIdAsync(int writerId);
        Task<IResult> BlogStatusUpdateAsync(int blogId);
        Task<IDataResult<BlogDto>> GetByBlogSlugNameAsync(string slugName);
    }
}
