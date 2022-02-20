using Dtos.Message;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogUI.ApiServices
{
    public class MessageApiService
    {
        private readonly HttpClient _client;

        public MessageApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<MessageDto>> GetMessageListByWriterMailAsync(string email)
        {
            var response = await _client.GetAsync($"messages/getmessagelistbywritermail/{email}");
            var result = JsonConvert.DeserializeObject<List<MessageDto>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode) return result;
            return null;
        }
    }
}
