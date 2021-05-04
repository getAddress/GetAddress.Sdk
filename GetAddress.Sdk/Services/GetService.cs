using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Sdk.Services
{
    public class GetService: AddressService
    {
        public GetService(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public async Task<Result<SuccessfulGet>> Get(Suggestion suggestion, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(suggestion.Url);

            var response = await HttpGet(requestUri, administrationOrApiKey: ApiKey, token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulGet>();
        }

    }
}
