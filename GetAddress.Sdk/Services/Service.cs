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
        public HttpClient HttpClient { get; }

        protected Service(HttpClient httpClient = null)
        {
            this.HttpClient = httpClient ?? new GetAddressHttpClient();
        }

        

        private void SetAuthorization(string administrationOrApiKey = null, Token token = default)
        {
            HttpClient.ClearAuthorization();

            if (token != null)
            {
                HttpClient.SetBearerToken(token.Value);
            }
            else if (!string.IsNullOrWhiteSpace(administrationOrApiKey))
            {
                HttpClient.SetApiKeyAuthorization(administrationOrApiKey);
            }

        }

        protected async Task<HttpResponseMessage> HttpGet(Uri requestUri, string administrationOrApiKey = null,
            Token token = null, CancellationToken cancellationToken = default)
        {
            SetAuthorization(administrationOrApiKey: administrationOrApiKey, token: token);

            return await HttpClient.GetAsync(requestUri, cancellationToken);
        }

        protected async Task<HttpResponseMessage> HttpPost(Uri requestUri,HttpContent httpContent = null, string administrationOrApiKey = null,
            Token token = null, CancellationToken cancellationToken = default)
        {
            SetAuthorization(administrationOrApiKey: administrationOrApiKey, token: token);

            return await HttpClient.PostAsync(requestUri, httpContent, cancellationToken: cancellationToken);
        }

        protected async Task<HttpResponseMessage> HttpDelete(Uri requestUri, string administrationOrApiKey = null,
            Token token = null, CancellationToken cancellationToken = default)
        {
            SetAuthorization(administrationOrApiKey: administrationOrApiKey, token: token);

            return await HttpClient.DeleteAsync(requestUri, cancellationToken: cancellationToken);
        }

        protected Uri GetUri(string path, NameValueCollection nameValueCollection = null)
        {
            var uriBuilder = new UriBuilder(HttpClient.BaseAddress); 

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

    public abstract class AddressService : Service
    {
        public string ApiKey { get; set; }

        public AddressService(string apiKey, HttpClient httpClient = null) : base(httpClient)
        {
            ApiKey = apiKey;
        }
    }

}
