using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class GetLocationService: AddressService
    {
        public GetLocationService(AddressLookupKey addressLookupKey, HttpClient httpClient = null) : base(addressLookupKey?.Key, httpClient)
        {
        }

        public async Task<Result<SuccessfulGetLocation>> GetLocation(LocationSuggestion suggestion, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(suggestion.Url);

            return await HttpGet<SuccessfulGetLocation>(requestUri, administrationOrApiKey: AddressLookupKey, token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulGetLocation>> GetLocation(string id, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var path = $"get-location/{id}";

            var requestUri = GetUri(path);

            return await HttpGet<SuccessfulGetLocation>(requestUri, administrationOrApiKey: AddressLookupKey, token: accessToken, cancellationToken: cancellationToken);
        }

    }
}
