using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GetAddress.Sdk.Services
{
    public class AuthService //todo: base class
    {
        public const string Path = "security/token/";
        private readonly HttpClient httpClient;

        public AuthService(string administrationKey, HttpClient httpClient = null)
        {
            AdministrationKey = administrationKey;

            this.httpClient = httpClient ?? new HttpClient();
        }

        public async Task<Result<SuccessfulAuth>> Get(string administrationKey = null, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(administrationKey);

            var response = await httpClient.GetAsync(requestUri, cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var success = JsonConvert.DeserializeObject<SuccessfulAuth>(content);

                return new Result<SuccessfulAuth>(success);
            }

            var failed = JsonConvert.DeserializeObject<Failed>(content);

            return new Result<SuccessfulAuth>(failed);
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
                throw new Exception();//todo: add message
            }

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }

        public string AdministrationKey { get; set; }

        public Uri BaseAddress
        {
            get;
            set;
        } = new Uri("https://api.getaddress.io/");
    }
}
