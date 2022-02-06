using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dtos.About;
using Newtonsoft.Json;

namespace BlogUI.ApiServices
{
    public class AboutApiService
    {
        private readonly HttpClient _client;

        public AboutApiService(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<AboutDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("abouts");
            var result = JsonConvert.DeserializeObject<List<AboutDto>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode) return result;
            return null;
        }
    }
}
