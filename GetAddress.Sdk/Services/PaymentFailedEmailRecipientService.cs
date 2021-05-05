using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Sdk.Services
{
    public class PaymentFailedEmailRecipientService : AdministrationService
    {
        private const string path = "email-notification/payment-failed/";

        public PaymentFailedEmailRecipientService(string administrationKey, HttpClient httpClient = null) : base(administrationKey, httpClient)
        {

        }

        public async Task<Result<SuccessfulPaymentFailedEmailRecipient>> Get(string id,
           AccessToken accessToken = default,
           CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulPaymentFailedEmailRecipient>();
        }

        public async Task<Result<SuccessfulPaymentFailedEmailRecipient[]>> Get(
      AccessToken accessToken = default,
      CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulPaymentFailedEmailRecipient[]>();
        }

        public async Task<Result<SuccessfulPaymentFailedReachedEmailRecipientAdd>> Add(AddPaymentFailedEmailRecipient request,
           AccessToken accessToken = default,
           CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var content = request.ToHttpContent();

            var response = await HttpPost(requestUri, httpContent: content, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulPaymentFailedReachedEmailRecipientAdd>();
        }

        public async Task<Result<SuccessfulPaymentFailedReachedEmailRecipientRemove>> Remove(string id,
         AccessToken accessToken = default,
         CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            var response = await HttpDelete(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulPaymentFailedReachedEmailRecipientRemove>();
        }

    }
}
