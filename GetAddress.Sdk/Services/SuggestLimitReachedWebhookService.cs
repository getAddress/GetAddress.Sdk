using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class SuggestLimitReachedWebhookService : AdministrationService
    {
        private const string path = "webhook/suggest-limit-reached";

        public SuggestLimitReachedWebhookService(AdministrationKey administrationKey, HttpClient httpClient = null) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<SuggestLimitReached>> Get(string id,
           AccessToken accessToken = default,
           CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpGet<SuggestLimitReached>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuggestLimitReached[]>> Get(
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpGet<SuggestLimitReached[]>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

        }

        public async Task<Result<SuccessfulSuggestLimitReachedWebhookAdd>> Add(AddSuggestLimitReachedWebhook request,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulSuggestLimitReachedWebhookAdd>(requestUri,
                data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }


        public async Task<Result<SuccessfulSuggestLimitReachedWebhookRemove>> Remove(string id,
        AccessToken accessToken = default,
        CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpDelete<SuccessfulSuggestLimitReachedWebhookRemove>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulSuggestLimitReachedWebhookTest>> Test(
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var fullPath = $"{path}/test";

            var requestUri = GetUri(fullPath);

            return await HttpPost<SuccessfulSuggestLimitReachedWebhookTest>(requestUri, administrationOrApiKey: AdministrationKey,
                 token: accessToken, cancellationToken: cancellationToken);
        }

    }
}
