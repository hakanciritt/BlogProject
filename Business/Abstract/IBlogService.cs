using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IDataResult<object> Add(Blog blog);
        IDataResult<object> Update(Blog blog);
        IResult Delete(Blog blog);
        IDataResult<List<Blog>> GetAll();
        IDataResult<Blog> GetById(int id);
        IDataResult<List<Blog>> GetBlogListWithCategory();
        IDataResult<List<Blog>> GetAllBlogListWithCategory();
        IDataResult<List<Blog>> GetBlogListByWriterId(int writerId);
        IDataResult<List<Blog>> GetLastThreeBlog();
        IDataResult<List<Blog>> GetBlogListAndCategoryByWriterId(int writerId);
        IResult BlogStatusUpdate(int blogId);
        IDataResult<List<Blog>> TotalCommentsToAuthorsBlog(int writerId);
        IDataResult<Blog> GetByBlogSlugName(string slugName);
    }
}
