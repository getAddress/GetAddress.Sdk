using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class LoginRequestedWebhookService : AdministrationService
    {
        private const string path = "webhook/login-requested";

        public LoginRequestedWebhookService(AdministrationKey administrationKey, HttpClient httpClient = null) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<LoginRequested>> Get(string id,
           AccessToken accessToken = default,
           CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpGet<LoginRequested>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<LoginRequested[]>> Get(
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpGet<LoginRequested[]>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulLoginRequestedWebhookAdd>> Add(AddLoginRequestedWebhook request,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var nameValueCollection = request.Options?.GetNameValueCollectionOrDefault();

            var requestUri = GetUri(path,nameValueCollection);

            return await HttpPost<SuccessfulLoginRequestedWebhookAdd>(requestUri, data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulLoginRequestedWebhookRemove>> Remove(string id,
          AccessToken accessToken = default,
          CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpDelete<SuccessfulLoginRequestedWebhookRemove>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulExpiredWebhookTest>> Test(
           AccessToken accessToken = default,
           CancellationToken cancellationToken = default)
        {
            var fullPath = $"{path}/test";

            var requestUri = GetUri(fullPath);

            return await HttpPost<SuccessfulExpiredWebhookTest>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

    }
}
