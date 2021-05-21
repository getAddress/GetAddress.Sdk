using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{

    public class DailyLimitReachedEmailRecipientService: AdministrationService
    {
        private const string path = "email-notification/daily-limit-reached";

        public DailyLimitReachedEmailRecipientService(AdministrationKey administrationKey, HttpClient httpClient = null) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<SuccessfulDailyLimitReachedEmailRecipient>> Get(string id,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpGet<SuccessfulDailyLimitReachedEmailRecipient>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulDailyLimitReachedEmailRecipient[]>> Get(
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpGet<SuccessfulDailyLimitReachedEmailRecipient[]>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulDailyLimitReachedEmailRecipientAdd>> Add(AddDailyLimitReachedEmailRecipient request,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulDailyLimitReachedEmailRecipientAdd>(requestUri, data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulDailyLimitReachedEmailRecipientRemove>> Remove(string id,
          AccessToken accessToken = default,
          CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpDelete<SuccessfulDailyLimitReachedEmailRecipientRemove>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }
    }
}
