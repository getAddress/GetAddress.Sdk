using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class MonthlyReserveReachedEmailRecipientService : AdministrationService
    {
        private const string path = "email-notification/monthly-limit-reached";

        public MonthlyReserveReachedEmailRecipientService(AdministrationKey administrationKey, HttpClient httpClient = null) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<SuccessfulMonthlyReserveReachedEmailRecipient>> Get(string id,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpGet<SuccessfulMonthlyReserveReachedEmailRecipient>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulMonthlyReserveReachedEmailRecipient[]>> Get(
          AccessToken accessToken = default,
          CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpGet<SuccessfulMonthlyReserveReachedEmailRecipient[]>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulMonthlyReserveReachedEmailRecipientAdd>> Add(AddMonthlyReserveReachedEmailRecipient request,
           AccessToken accessToken = default,
           CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulMonthlyReserveReachedEmailRecipientAdd>(requestUri, data: request, administrationOrApiKey: AdministrationKey, token: accessToken, cancellationToken: cancellationToken); 
        }

        public async Task<Result<SuccessfulMonthlyReserveReachedEmailRecipientRemove>> Remove(string id,
         AccessToken accessToken = default,
         CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpDelete<SuccessfulMonthlyReserveReachedEmailRecipientRemove>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

    }
}
