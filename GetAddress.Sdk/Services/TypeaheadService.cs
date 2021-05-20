using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class TypeaheadService : AddressService
    {
        public TypeaheadService(AddressLookupKey addressLookupKey, HttpClient httpClient = null) : base(addressLookupKey?.Key, httpClient)
        {

        }

        public async Task<Result<string[]>> Typeahead(string term,
            TypeaheadOptions options = default, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            options = options ?? new TypeaheadOptions();

            var path = GetPath(term);

            var requestUri = GetUri(path);

            return await HttpPost<string[]>(requestUri, data: options, administrationOrApiKey: AddressLookupKey, 
                token: accessToken, cancellationToken: cancellationToken);
        }

        private string GetPath(string term)
        {
            return $"Typeahead/{term}";
        }
    }
}
