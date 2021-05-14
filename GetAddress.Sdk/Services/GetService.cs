using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class GetService: AddressService
    {
        public GetService(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public async Task<Result<SuccessfulGet>> Get(Suggestion suggestion, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(suggestion.Url);

            return await HttpGet<SuccessfulGet>(requestUri, administrationOrApiKey: ApiKey, token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulGet>> Get(string id, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var path = $"Get/{id}";

            var requestUri = GetUri(path);

            return await HttpGet<SuccessfulGet>(requestUri, administrationOrApiKey: ApiKey, token: accessToken, cancellationToken: cancellationToken);
        }

    }
}
