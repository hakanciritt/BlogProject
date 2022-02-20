using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Core.ResponseModel;
using Dtos.Blog;

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

        [HttpGet("getbloglistwithcategory")]
        public async Task<IActionResult> GetBlogListWithCategoryAsync()
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

        [HttpGet("getbloglistbywriterid/{userId}")]
        public async Task<IActionResult> GetBlogListByWriterIdAsync(int userId)
        {
            var result = await _blogService.GetBlogListByWriterIdAsync(userId);
            return Ok(result.Data);
        }
    }
}
