using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GetAddress.Sdk
{
    public abstract class Options
    {
        [JsonIgnore]
        public string Version { get; set; } = $"2020-09-09";

        public HttpContent ToHttpContent()
        {
            var jsonString = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpContent;
        }
    }
}
