using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GetAddress.Services
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

        

        protected async Task<Result<S>> HttpGet<S>(Uri requestUri, string administrationOrApiKey = null,
            Token token = null, CancellationToken cancellationToken = default) where S :class
        {
            SetAuthorization(administrationOrApiKey: administrationOrApiKey, token: token);

            var result = await HttpClient.GetAsync(requestUri, cancellationToken);

            return await result.ToResult<S>();
        }

        

        protected async Task<Result<S>> HttpPost<S>(Uri requestUri, object data = null, string administrationOrApiKey = null,
            Token token = null, CancellationToken cancellationToken = default)where S:class
        {
            SetAuthorization(administrationOrApiKey: administrationOrApiKey, token: token);

            var httpContent = data == null ? null : data.ToHttpContent();

            var response = await HttpClient.PostAsync(requestUri, httpContent, cancellationToken: cancellationToken);

            return await response.ToResult<S>();
        }

        protected async Task<Result<S>> HttpPut<S>(Uri requestUri, object data = null, string administrationOrApiKey = null,
            Token token = null, CancellationToken cancellationToken = default) where S : class
        {
            SetAuthorization(administrationOrApiKey: administrationOrApiKey, token: token);

            var httpContent = data == null ? null : data.ToHttpContent();

            var response = await HttpClient.PutAsync(requestUri, httpContent, cancellationToken: cancellationToken);

            return await response.ToResult<S>();
        }


        protected async Task<Result<S>> HttpDelete<S>(Uri requestUri, string administrationOrApiKey = null,
            Token token = null, CancellationToken cancellationToken = default)where S:class
        {
            SetAuthorization(administrationOrApiKey: administrationOrApiKey, token: token);

            var response = await HttpClient.DeleteAsync(requestUri, cancellationToken: cancellationToken);

            return await response.ToResult<S>();
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
