using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{

    public class ApiKeyService : AdministrationService
    {
        private const string path = "security/api-key";
        public ApiKeyService(AdministrationKey administrationKey, HttpClient httpClient = null) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<SuccessfulApiKey>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpGet<SuccessfulApiKey>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulApiKeyUpdate>> Update(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpPut<SuccessfulApiKeyUpdate>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

        }

        public async Task<Result<SuccessfulApiKeyUpdate>> Swap(SwapApiKey swapApiKey, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var swapPath = path + "/swap";

            var requestUri = GetUri(swapPath);

            return await HttpPut<SuccessfulApiKeyUpdate>(requestUri,data:swapApiKey, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

        }

    }
}
