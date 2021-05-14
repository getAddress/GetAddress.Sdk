using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class AutocompleteService: AddressService
    {
        public AutocompleteService(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public async Task<Result<SuccessfulAutocomplete>> Autocomplete(string term,
            AutocompleteOptions options = default, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            options = options ?? new AutocompleteOptions();

            var path = GetAutocompletePath(term);

            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulAutocomplete>(requestUri, 
                data: options,
                administrationOrApiKey: ApiKey, 
                token: accessToken, cancellationToken: cancellationToken);
        }

        

        private string GetAutocompletePath(string term)
        {
            return $"Autocomplete/{term}";
        }
    }
}
