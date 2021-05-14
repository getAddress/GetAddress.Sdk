using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
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

            return await HttpPost<SuccessfulMonthlyReserveReachedWebhookAdd>(requestUri, data: request, administrationOrApiKey: AdministrationKey,  token: accessToken, cancellationToken: cancellationToken);

        }

        public async Task<Result<SuccessfulMonthlyReserveReachedWebhookRemove>> Remove(string id,
          AccessToken accessToken = default,
          CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpDelete<SuccessfulMonthlyReserveReachedWebhookRemove>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulMonthlyReserveReachedWebhookTest>> Test(
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var fullPath = $"{path}/test";

            var requestUri = GetUri(fullPath);

            return await HttpPost<SuccessfulMonthlyReserveReachedWebhookTest>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }


    }
}
