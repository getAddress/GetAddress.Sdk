using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Sdk.Services
{
    public class PlansService: AdministrationService
    {
        private const string path = "plans/";
        public PlansService(string administrationKey, HttpClient httpClient = null) : base(administrationKey, httpClient)
        {

        }

        public async Task<Result<SuccessfulPlans>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulPlans>();
        }
    }
}
