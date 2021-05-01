using GetAddress.Sdk.Services;
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
            this.httpClient = httpClient ?? new HttpClient();
        }
        public GetAddressApi(string apiKey, string administrationKey, HttpClient httpClient = null):this(httpClient)
        {
            ApiKey = apiKey;
            AdministrationKey = administrationKey;
            Security = new Security(apiKey, administrationKey, httpClient);
        }

        public Security Security
        {
            get;
        } 

        public async Task<Result<SuccessfulFind>> Find(string postcode, 
            FindOptions options = default, AccessToken accessToken = default,  CancellationToken cancellationToken = default)//todo: optional auth token
        {
            options = options ?? new FindOptions();

            var requestUri = GetFindUri(postcode, options, accessToken);

            var response = await httpClient.GetAsync(requestUri, cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var success = JsonConvert.DeserializeObject<SuccessfulFind>(content);

                return new Result<SuccessfulFind>(success,response.StatusCode);
            }
            
            var failed = JsonConvert.DeserializeObject<Failed>(content);

            return new Result<SuccessfulFind>(failed, response.StatusCode);
        }

        private Uri GetFindUri(string postcode, FindOptions options, AccessToken accessToken = default)
        {
            var uriBuilder = new UriBuilder(BaseAddress);

            uriBuilder.Path = GetFindPath(postcode, options);

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            if(accessToken != default)
            {
                httpClient.SetBearerToken(accessToken.Value);
            }
            else if (!string.IsNullOrWhiteSpace(ApiKey))
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

        

        public Uri BaseAddress
        {
            get;
            set;
        } = new Uri("https://api.getaddress.io/");

        
        public string ApiKey { get; set; }
        public string AdministrationKey { get; set; }
    }
}
