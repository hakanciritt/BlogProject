﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlogUI.ApiServices.ContentTypes;
using Core.ResponseModel;
using Core.Utilities.Results;
using Dtos.Blog;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BlogUI.ApiServices
{
    public class BlogApiService
    {
        private readonly HttpClient _client;

        public BlogApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResponse<AddBlogDto>> AddAsync(AddBlogDto blogDto)
        {
            var content = new ContentTypes.JsonContent(blogDto.ToString());
            var client = await _client.PostAsJsonAsync("blogs", content);
            var responseContent = await client.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ApiResponse<AddBlogDto>>(responseContent);

            return response;
        }
        public async Task<List<BlogDto>> GetBlogListWithCategoryAsync()
        {
            var result = await _client.GetAsync("blogs/getbloglistwithcategory");
            var response = JsonConvert.DeserializeObject<List<BlogDto>>(await result.Content.ReadAsStringAsync());
            if (result.IsSuccessStatusCode) return response;

            return null;
        }
        public async Task<BlogDto> GetByBlogSlugNameAsync(string blogSlug)
        {
            var result = await _client.GetAsync($"blogs/{blogSlug}");
            var response = JsonConvert.DeserializeObject<BlogDto>(await result.Content.ReadAsStringAsync());
            if (result.IsSuccessStatusCode) return response;

            return null;
        }
        public async Task<List<BlogDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("blogs");
            var result = JsonConvert.DeserializeObject<List<BlogDto>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode) return result;
            return null;
        }
        public async Task<List<BlogDto>> GetBlogListByWriterIdAsync(int userId)
        {
            var response = await _client.GetAsync($"blogs/getbloglistbywriterid/{userId}");
            var result = JsonConvert.DeserializeObject<List<BlogDto>>(await response.Content.ReadAsStringAsync());
            return result;

        }
    }
}
