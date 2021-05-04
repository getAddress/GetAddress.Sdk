using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Sdk.Services
{
    public class DistanceService : AddressService
    {
        public DistanceService(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {

        }

        public async Task<Result<SuccessfulDistance>> Distance(
            string postcodeFrom,
            string postcodeTo,
            AccessToken accessToken = default, 
            CancellationToken cancellationToken = default)
        {
            var path = GetPath(postcodeFrom,postcodeTo);

            var requestUri = GetUri(path);

            var response = await HttpGet(requestUri, administrationOrApiKey: ApiKey,
               token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulDistance>();
        }

        private string GetPath(string postcodeFrom, string postcodeTo)
        {
            return $"Distance/{postcodeFrom}/{postcodeTo}";
        }
    }
}
