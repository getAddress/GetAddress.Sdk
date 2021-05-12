using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class IpAddressWhitelistService : AdministrationService
    {
        private const string path = "security/ip-address-whitelist";
        public IpAddressWhitelistService(string administrationKey, HttpClient httpClient = null) : base(administrationKey, httpClient)
        {

        }

        public async Task<Result<SuccessfulIpAddressWhitelist[]>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulIpAddressWhitelist[]>();
        }

        public async Task<Result<SuccessfulIpAddressWhitelist>> Get(string id, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var pathAndId = $"{path}/{id}";

            var requestUri = GetUri(pathAndId);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulIpAddressWhitelist>();
        }

        public async Task<Result<SuccessfulIpAddressWhitelistAdd>> Add(AddIpAddress request,
           AccessToken accessToken = default,
           CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var content = request.ToHttpContent();

            var response = await HttpPost(requestUri, httpContent: content, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulIpAddressWhitelistAdd>();
        }

        public async Task<Result<SuccessfulIpAddressWhitelistRemove>> Remove(string id,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            var response = await HttpDelete(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulIpAddressWhitelistRemove>();
        }
    }
}
