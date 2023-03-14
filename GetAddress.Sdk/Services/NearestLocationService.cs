using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class NearestLocationService : AddressService
    {
        public NearestLocationService(AddressLookupKey addressLookupKey, HttpClient httpClient = null) : base(addressLookupKey?.Key, httpClient)
        {
        }

        public async Task<Result<SuccessfulNearestLocation>> NearestLocation(double latitude, double longitude,
            NearestLocationOptions options = default, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            options = options ?? new NearestLocationOptions();

            var path = GetNearestPath(latitude, longitude);

            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulNearestLocation>(requestUri,
                data: options,
                administrationOrApiKey: AddressLookupKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        private string GetNearestPath(double latitude, double longitude)
        {
            return $"Nearest-Location/{latitude}/{longitude}";
        }
    }

}
