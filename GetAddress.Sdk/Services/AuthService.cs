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

        public Security(string administrationKey, HttpClient httpClient = null)
        {
            authService = new AuthService(administrationKey, httpClient);
        }
    }

    public class AuthService: AdministrationService
    {
        public const string Path = "security/token";

        public AuthService(string administrationKey, HttpClient httpClient = null):base(administrationKey,httpClient)
        {

        }

        public async Task<Result<SuccessfulAuth>> Get(string administrationKey = null, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(administrationKey);

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

        private Uri GetUri(string administrationKey = null)
        {
            var uriBuilder = new UriBuilder(BaseAddress);

            uriBuilder.Path = Path;

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            administrationKey = administrationKey ?? AdministrationKey;

            if (!string.IsNullOrWhiteSpace(administrationKey))
            {
                query.Add("api-key", administrationKey);
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
