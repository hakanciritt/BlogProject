using System.Net.Http;
using System.Threading.Tasks;
using Dtos.Writer;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;

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
            var result = JsonConvert.DeserializeObject<WriterDto>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return result;
            }
            else
            {
                return null;
            }

        }
    }
}
