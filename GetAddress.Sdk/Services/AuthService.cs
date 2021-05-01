using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GetAddress.Sdk.Services
{
    public class Security
    {
        private readonly AuthService authService;

        public AuthService Token
        {
            get
            {
                return authService;
            }
        }

        public Security(string apiKey, string administrationKey, HttpClient httpClient = null)
        {
            authService = new AuthService(apiKey, administrationKey, httpClient);
        }
    }

    public class AuthService: Service
    {
        public const string Path = "security/token";

        public AuthService(string apiKey, string administrationKey, HttpClient httpClient = null):base(httpClient)
        {
            ApiKey = apiKey;
            AdministrationKey = administrationKey;
        }

        public string ApiKey { get; set; }

        public string AdministrationKey { get; set; }

        public  async Task<Result<SuccessfulAuth>> GetAdministrationTokens(string administrationKey = null, CancellationToken cancellationToken = default)
        {
            administrationKey = administrationKey ?? AdministrationKey;

            return await Get(administrationKey, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulAuth>> GetTokens(string apiKey = null, CancellationToken cancellationToken = default)
        {
            apiKey = apiKey ?? ApiKey;

            return await Get(apiKey, cancellationToken: cancellationToken);
        }


        private async Task<Result<SuccessfulAuth>> Get(string administrationOrApiKey = null, CancellationToken cancellationToken = default)
        {
            

            var requestUri = GetUri(administrationOrApiKey);

            var response = await httpClient.GetAsync(requestUri, cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var success = JsonConvert.DeserializeObject<SuccessfulAuth>(content);

                return new Result<SuccessfulAuth>(success, response.StatusCode);
            }

            var failed = JsonConvert.DeserializeObject<Failed>(content);

            return new Result<SuccessfulAuth>(failed, response.StatusCode);
        }

        private Uri GetUri(string administrationOrApiKey = null)
        {
            var uriBuilder = new UriBuilder(BaseAddress);

            uriBuilder.Path = Path;

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            if (!string.IsNullOrWhiteSpace(administrationOrApiKey))
            {
                query.Add("api-key", administrationOrApiKey);
            }
            else
            {
                throw new Exception("administration key required");
            }

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }

    }

        
    
}
