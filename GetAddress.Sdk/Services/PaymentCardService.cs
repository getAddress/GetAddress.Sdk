using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class PaymentCardService: AdministrationService
    {
        private const string path = "payment-card";
        public PaymentCardService(AdministrationKey administrationKey, HttpClient httpClient = null) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<SuccessfulPaymentCard>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpGet<SuccessfulPaymentCard>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulPaymentCardRemove>> Remove(string id,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpDelete<SuccessfulPaymentCardRemove>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulPaymentCardUpdate>> SetDefault(string id, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var updatePath = path + $"/{id}";

            var requestUri = GetUri(updatePath);

            return await HttpPut<SuccessfulPaymentCardUpdate>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulPaymentCardAdd>> Add(AddPaymentCard request, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulPaymentCardAdd>(requestUri, data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

        }
    }
}
