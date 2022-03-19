using Core.ResponseModel;
using Dtos.Blog;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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
            var client = await _client.PostAsJsonAsync("blogs", blogDto);
            var responseContent = await client.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ApiResponse<AddBlogDto>>(responseContent);
            return response;
        }

        public async Task<ApiResponse<BlogDto>> GetByIdAsync(int blogId)
        {
            var response = await _client.GetAsync($"blogs/getbyid/{blogId}");
            var result = JsonConvert.DeserializeObject<ApiResponse<BlogDto>>(await response.Content.ReadAsStringAsync());
            return result;
        }
        public async Task<ApiResponse<BlogDto>> UpdateAsync(BlogDto blog)
        {
            var content = new ContentTypes.JsonContent(blog.ToString());
            var client = await _client.PutAsync("blogs", content);
            var responseContent = await client.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ApiResponse<BlogDto>>(responseContent);
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
