using GetAddress;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace System.Net.Http
{
    internal static class HttpMessageResponseExtensions
    {
        public static async Task<Result<S>> ToResult<S>(this HttpResponseMessage response) where S: class
        {
            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var success = JsonConvert.DeserializeObject<S>(json);

                return new Result<S>(success, json, response.StatusCode);
            }
            try
            {
                var failed = JsonConvert.DeserializeObject<Failed>(json);

                failed = failed ?? new Failed();

                return new Result<S>(failed, json, response.StatusCode);
            }
            catch(Exception)
            {
                var failed = new Failed { Message = response.StatusCode.ToString() };
                return new Result<S>(failed, json, response.StatusCode);
            }
        }
    }
}
