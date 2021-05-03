using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GetAddress.Sdk.Services
{
    public abstract class Service
    {
        protected readonly HttpClient httpClient;

        protected Service(HttpClient httpClient = null)
        {
            this.httpClient = httpClient ?? new HttpClient();
        }

        public Uri BaseAddress
        {
            get;
            set;
        } = new Uri("https://api.getaddress.io/");

        private void SetAuthorization(string administrationOrApiKey = null, Token token = default)
        {
            httpClient.ClearAuthorization();

            if (token != null)
            {
                httpClient.SetBearerToken(token.Value);
            }
            else if (!string.IsNullOrWhiteSpace(administrationOrApiKey))
            {
                httpClient.SetApiKeyAuthorization(administrationOrApiKey);
            }
            else
            {
                throw new Exception("administration key required");
            }
        }

        protected async Task<HttpResponseMessage> HttpGet(Uri requestUri, string administrationOrApiKey = null,
            Token token = null, CancellationToken cancellationToken = default)
        {
            SetAuthorization(administrationOrApiKey: administrationOrApiKey, token: token);

            return await httpClient.GetAsync(requestUri, cancellationToken);
        }

        protected async Task<HttpResponseMessage> HttpPost(Uri requestUri,HttpContent httpContent = null, string administrationOrApiKey = null,
            Token token = null, CancellationToken cancellationToken = default)
        {
            SetAuthorization(administrationOrApiKey: administrationOrApiKey, token: token);

            return await httpClient.PostAsync(requestUri, httpContent, cancellationToken: cancellationToken);
        }

        protected Uri GetUri(string path, NameValueCollection nameValueCollection = null)
        {
            var uriBuilder = new UriBuilder(BaseAddress);

            uriBuilder.Path = path;

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            if (nameValueCollection != null)
            {
                query.Add(nameValueCollection);
            }

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }
    }

    public abstract class AdministrationService:Service
    {
        public string AdministrationKey { get; set; }

        public AdministrationService(string administrationKey, HttpClient httpClient = null) : base(httpClient)
        {
            AdministrationKey = administrationKey;
        }
    }

    public abstract class ApiKeyService : Service
    {
        public string ApiKey { get; set; }

        public ApiKeyService(string apiKey, HttpClient httpClient = null) : base(httpClient)
        {
            ApiKey = apiKey;
        }
    }

}
