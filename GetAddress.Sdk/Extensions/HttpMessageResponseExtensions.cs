using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetAddress.Sdk
{
    internal static class HttpMessageResponseExtensions
    {
        public static async Task<Result<S>> ToResult<S>(this HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var success = JsonConvert.DeserializeObject<S>(json);

                return new Result<S>(success, json, response.StatusCode);
            }

            var failed = JsonConvert.DeserializeObject<Failed>(json);

            return new Result<S>(failed, json, response.StatusCode);
        }
    }
}
