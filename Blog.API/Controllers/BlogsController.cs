using Business.Abstract;
using Core.ResponseModel;
using Dtos.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _blogService.GetAllAsync();
            return Ok(result.Data);
        }
        [HttpGet("getbyid/{blogId}")]
        public async Task<IActionResult> GetById(int blogId)
        {
            var response = new ApiResponse<BlogDto>();
            var result = await _blogService.GetByIdAsync(blogId);
            response.IsSuccess = result.Success;
            response.Data = result.Data;
            return Ok(response);
        }
        [HttpGet("getbloglistwithcategory")]
        public async Task<IActionResult> GetBlogListWithCategory()
        {
            var result = await _blogService.GetBlogListWithCategoryAsync();
            return Ok(result.Data);
        }
        [HttpGet("{blogSlug}")]
        public async Task<IActionResult> GetBlog(string blogSlug)
        {
            var result = await _blogService.GetByBlogSlugNameAsync(blogSlug);
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddBlogDto blogDto)
        {
            var response = new ApiResponse<AddBlogDto>();
            var result = await _blogService.AddAsync(blogDto);
            response.Data = result.Data;
            response.IsSuccess = result.Success;

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BlogDto blogDto)
        {
            var response = new ApiResponse<BlogDto>();
            var result = await _blogService.UpdateAsync(blogDto);
            response.IsSuccess = result.Success;
            response.Data = result.Data;
            return Ok(response);
        }
        [HttpGet("getbloglistbywriterid/{userId}")]
        public async Task<IActionResult> GetBlogListByWriterIdAsync(int userId)
        {
            var result = await _blogService.GetBlogListByWriterIdAsync(userId);
            return Ok(result.Data);
        }
    }
}
