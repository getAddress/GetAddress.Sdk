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

            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var success = JsonConvert.DeserializeObject<SuccessfulAuth>(json);

                return new Result<SuccessfulAuth>(success, json,response.StatusCode);
            }

            var failed = JsonConvert.DeserializeObject<Failed>(json);

            return new Result<SuccessfulAuth>(failed, json, response.StatusCode);
        }

        public async Task<Result<SuccessfulAuth>> Refresh(RefreshToken refreshToken, CancellationToken cancellationToken = default)
        {
            var path = Path + "/refresh";

            var requestUri = GetUri(refreshToken:refreshToken,path:path);

            var response = await httpClient.PostAsync(requestUri,null, cancellationToken: cancellationToken);

            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var success = JsonConvert.DeserializeObject<SuccessfulAuth>(json);

                return new Result<SuccessfulAuth>(success, json, response.StatusCode);
            }

            var failed = JsonConvert.DeserializeObject<Failed>(json);

            return new Result<SuccessfulAuth>(failed, json, response.StatusCode);
        }

        private Uri GetUri(string administrationOrApiKey = null, RefreshToken refreshToken = default, string path = null)
        {
            var uriBuilder = new UriBuilder(BaseAddress);

            path = path ?? Path;

            uriBuilder.Path = path;

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            httpClient.ClearAuthorization();

            if(refreshToken != null)
            {
                httpClient.SetBearerToken(refreshToken.Value);
            }
            else if(!string.IsNullOrWhiteSpace(administrationOrApiKey))
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
