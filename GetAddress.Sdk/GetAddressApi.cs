using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Sdk
{
    public class GetAddressApi
    {
        private readonly HttpClient httpClient;
        
        public GetAddressApi(string apiKey, string administrationKey, HttpClient httpClient = null)
        {
            ApiKey = apiKey;
            AdministrationKey = administrationKey;
            this.httpClient = httpClient ?? GetHttpClient();
        }

        public async Task<FindResult> Find(string postcode, FindOptions options = default, CancellationToken cancellationToken = default)//todo: optional auth token
        {
            var response = await httpClient.GetAsync($"Find/{postcode}", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<SuccessfulFindResult>(content);

                return result;
            }
            //todo: return specific failed result
            return null;
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            httpClient.BaseAddress = BaseAddress;
            return client;
        }

        public Uri BaseAddress
        {
            get;
            set;
        } = new Uri("https://api.getaddress.io");

        
        public string ApiKey { get; set; }
        public string AdministrationKey { get; set; }
    }
}
