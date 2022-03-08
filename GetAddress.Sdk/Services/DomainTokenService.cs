using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class DomainTokenService : AdministrationService
    {
        private const string path = "security/domain-token";

        public DomainTokenService(AdministrationKey administrationKey, HttpClient httpClient = null) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<DomainToken>> Get(string host,AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri($"{path}/{host}/");

            return await HttpGet<DomainToken>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<DomainToken[]>> List(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpGet<DomainToken[]>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulDomainTokenRemove>> Remove(string host, 
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri($"{path}/{host}/");

            return await HttpDelete<SuccessfulDomainTokenRemove>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulDomainTokenAdd>> Add(AddDomainToken request, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulDomainTokenAdd>(requestUri, data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

    }
}
