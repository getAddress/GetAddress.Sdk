using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class LocationService: AddressService
    {
        public LocationService(AddressLookupKey addressLookupKey, HttpClient httpClient = null) : base(addressLookupKey?.Key, httpClient)
        {
        }

        public async Task<Result<SuccessfulLocation>> Location(string term,
            LocationOptions options = default, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            options = options ?? new LocationOptions();

            var path = GetLocationPath(term);

            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulLocation>(requestUri, 
                data: options,
                administrationOrApiKey: AddressLookupKey, 
                token: accessToken, cancellationToken: cancellationToken);
        }

        private string GetLocationPath(string term)
        {
            return $"Location/{term}";
        }
    }
}
