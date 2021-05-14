using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class TypeaheadService : AddressService
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

            return await HttpPost<string[]>(requestUri, data: options, administrationOrApiKey: ApiKey, 
                token: accessToken, cancellationToken: cancellationToken);
        }

        private string GetPath(string term)
        {
            return $"Typeahead/{term}";
        }
    }
}
