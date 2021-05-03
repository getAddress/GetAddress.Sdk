using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Sdk.Services
{
    public class TypeaheadService : ApiKeyService
    {
        public TypeaheadService(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {

        }

        public async Task<Result<string[]>> Typeahead(string term,
            TypeaheadOptions options = default, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            options = options ?? new TypeaheadOptions();

            var path = GetPath(term);

            var requestUri = GetUri(path);

            var content = options.ToHttpContent();

            var response = await HttpPost(requestUri,httpContent: content, administrationOrApiKey: ApiKey, token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<string[]>();
        }

        private string GetPath(string term)
        {
            return $"Typeahead/{term}";
        }
    }
}
