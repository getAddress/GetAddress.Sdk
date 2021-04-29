using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GetAddress.Sdk
{
    public class GetAddressApi
    {
        private readonly HttpClient httpClient;

        public GetAddressApi(HttpClient httpClient = null)
        {
            this.httpClient = httpClient ?? GetHttpClient();
        }
        public GetAddressApi(string apiKey, string administrationKey, HttpClient httpClient = null):this(httpClient)
        {
            ApiKey = apiKey;
            AdministrationKey = administrationKey;
        }

        public async Task<Result<SuccessfulFind>> Find(string postcode, FindOptions options = default, CancellationToken cancellationToken = default)//todo: optional auth token
        {
            options = options ?? new FindOptions();

            var requestUri = GetFindUri(postcode, options);

            var response = await httpClient.GetAsync(requestUri, cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var success = JsonConvert.DeserializeObject<SuccessfulFind>(content);

                return new Result<SuccessfulFind>(success);
            }
            
            var failed = JsonConvert.DeserializeObject<Failed>(content);

            return new Result<SuccessfulFind>(failed);
        }

        private Uri GetFindUri(string postcode, FindOptions options)
        {
            var uriBuilder = new UriBuilder(BaseAddress);

            uriBuilder.Path = GetFindPath(postcode, options);

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            if (!string.IsNullOrWhiteSpace(ApiKey))
            {
                query.Add("api-key", ApiKey);
            }
            else
            {
                throw new Exception();//todo: may have token
            }
            
            query.Add("api-version", options.Version);

            query.Add("expand", true.ToString());

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;

        }

        private string GetFindPath(string postcode, FindOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.HouseNameOrNumber))
            {
                return $"Find/{postcode}";
            }

            return $"Find/{postcode}/{options.HouseNameOrNumber}";
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            
            return client;
        }

        public Uri BaseAddress
        {
            get;
            set;
        } = new Uri("https://api.getaddress.io/");

        
        public string ApiKey { get; set; }
        public string AdministrationKey { get; set; }
    }
}
