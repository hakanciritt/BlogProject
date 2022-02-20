using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace BlogUI.ApiServices.ContentTypes
{
    public class JsonContent : StringContent
    {
        public JsonContent(string content) : base(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
        {
        }
    }
}
