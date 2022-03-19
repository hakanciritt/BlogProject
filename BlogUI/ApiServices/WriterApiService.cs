using Core.ResponseModel;
using Dtos.Writer;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogUI.ApiServices
{
    public class WriterApiService
    {
        private readonly HttpClient _client;

        public WriterApiService(HttpClient client)
        {
            _client = client;
        }
        public async Task<WriterDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync($"writers/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<WriterDto>(await response.Content.ReadAsStringAsync());
                return result;
            }
            else
            {
                return null;
            }
        }
        public async Task<ApiResponse<WriterUpdateDto>> UpdateAsync(WriterUpdateDto writer)
        {
            var content = new ContentTypes.JsonContent(writer.ToString());
            var res = await _client.PutAsync("writers", content);
            var responseContent = await res.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ApiResponse<WriterUpdateDto>>(responseContent);
            return response;
        }
    }
}
