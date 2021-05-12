using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class DomainWhitelistService : AdministrationService
    {
        private const string path = "security/domain-whitelist";
        public DomainWhitelistService(string administrationKey, HttpClient httpClient = null) : base(administrationKey, httpClient)
        {

        }

        public async Task<Result<SuccessfulDomainWhitelist[]>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulDomainWhitelist[]>();
        }

        public async Task<Result<SuccessfulDomainWhitelist>> Get(string id,AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var pathAndId = $"{path}/{id}";

            var requestUri = GetUri(pathAndId);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulDomainWhitelist>();
        }

        public async Task<Result<SuccessfulDomainWhitelistAdd>> Add(AddDomainName request,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var content = request.ToHttpContent();

            var response = await HttpPost(requestUri, httpContent: content, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulDomainWhitelistAdd>();
        }

        public async Task<Result<SuccessfulDomainWhitelistRemove>> Remove(string id,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            var response = await HttpDelete(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulDomainWhitelistRemove>();
        }

    }
}
