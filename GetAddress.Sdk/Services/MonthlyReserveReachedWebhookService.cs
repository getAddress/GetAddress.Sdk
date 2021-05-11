using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Sdk.Services
{
    public class MonthlyReserveReachedWebhookService : AdministrationService
    {
        private const string path = "webhook/second-limit-reached";

        public MonthlyReserveReachedWebhookService(string administrationKey, HttpClient httpClient = null) : base(administrationKey, httpClient)
        {

        }

        public async Task<Result<MonthlyReserveReached>> Get(string id,
           AccessToken accessToken = default,
           CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<MonthlyReserveReached>();
        }

        public async Task<Result<MonthlyReserveReached[]>> Get(
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<MonthlyReserveReached[]>();
        }

        public async Task<Result<SuccessfulMonthlyReserveReachedWebhookAdd>> Add(AddMonthlyReserveReachedWebhook request,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var content = request.ToHttpContent();

            var response = await HttpPost(requestUri, httpContent: content, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulMonthlyReserveReachedWebhookAdd>();
        }

        public async Task<Result<SuccessfulMonthlyReserveReachedWebhookRemove>> Remove(string id,
          AccessToken accessToken = default,
          CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            var response = await HttpDelete(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulMonthlyReserveReachedWebhookRemove>();
        }

    }
}
