using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class MonthlyReserveReachedEmailRecipientService : AdministrationService
    {
        private const string path = "email-notification/monthly-limit-reached/";

        public MonthlyReserveReachedEmailRecipientService(string administrationKey, HttpClient httpClient = null) : base(administrationKey, httpClient)
        {

        }

        public async Task<Result<SuccessfulMonthlyReserveReachedEmailRecipient>> Get(string id,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulMonthlyReserveReachedEmailRecipient>();
        }

        public async Task<Result<SuccessfulMonthlyReserveReachedEmailRecipient[]>> Get(
          AccessToken accessToken = default,
          CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulMonthlyReserveReachedEmailRecipient[]>();
        }

        public async Task<Result<SuccessfulMonthlyReserveReachedEmailRecipientAdd>> Add(AddMonthlyReserveReachedEmailRecipient request,
           AccessToken accessToken = default,
           CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var content = request.ToHttpContent();

            var response = await HttpPost(requestUri, httpContent: content, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulMonthlyReserveReachedEmailRecipientAdd>();
        }

        public async Task<Result<SuccessfulMonthlyReserveReachedEmailRecipientRemove>> Remove(string id,
         AccessToken accessToken = default,
         CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            var response = await HttpDelete(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulMonthlyReserveReachedEmailRecipientRemove>();
        }

    }
}
