using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class PlansService: AdministrationService
    {
        private const string path = "plans/";
        public PlansService(AdministrationKey administrationKey, HttpClient httpClient) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<SuccessfulPlans>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpGet<SuccessfulPlans>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }
    }
}
