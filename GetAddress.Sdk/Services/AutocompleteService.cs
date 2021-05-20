using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class AutocompleteService: AddressService
    {
        public AutocompleteService(AddressLookupKey addressLookupKey, HttpClient httpClient = null) : base(addressLookupKey?.Key, httpClient)
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
                administrationOrApiKey: AddressLookupKey, 
                token: accessToken, cancellationToken: cancellationToken);
        }

        private string GetAutocompletePath(string term)
        {
            return $"Autocomplete/{term}";
        }
    }
}
