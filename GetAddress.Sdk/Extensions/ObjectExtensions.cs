using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GetAddress.Sdk
{
    public static class ObjectExtensions
    {
        public static HttpContent ToHttpContent(this object obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpContent;
        }
    }
}
