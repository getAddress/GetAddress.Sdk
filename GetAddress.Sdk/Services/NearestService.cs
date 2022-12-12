using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class NearestService : AddressService
    {
        public NearestService(AddressLookupKey addressLookupKey, HttpClient httpClient = null) : base(addressLookupKey?.Key, httpClient)
        {
        }

        public async Task<Result<SuccessfulNearest>> Nearest(double latitude,double longitude,
            NearestOptions options = default, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            options = options ?? new NearestOptions();

            var path = GetNearestPath(latitude, longitude);

            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulNearest>(requestUri,
                data: options,
                administrationOrApiKey: AddressLookupKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        private string GetNearestPath(double latitude, double longitude)
        {
            return $"Nearest/{latitude}/{longitude}";
        }
    }

}
