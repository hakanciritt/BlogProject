using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Dtos.Writer;
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

        public async Task<bool> UpdateAsync(WriterUpdateDto writer)
        {
            var content = new ContentTypes.JsonContent(writer.ToString());

            var response = await _client.PutAsync("writers", content);
            if (response.StatusCode == HttpStatusCode.NoContent) return true;

            return false;
        }
    }
}
