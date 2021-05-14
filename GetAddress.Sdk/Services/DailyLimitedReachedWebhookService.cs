﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class DailyLimitedReachedWebhookService : AdministrationService
    {
        private const string path = "webhook/first-limit-reached";

        public DailyLimitedReachedWebhookService(string administrationKey, HttpClient httpClient = null) : base(administrationKey, httpClient)
        {

        }

        public async Task<Result<DailyLimitReached>> Get(string id,
           AccessToken accessToken = default,
           CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<DailyLimitReached>();
        }

        public async Task<Result<DailyLimitReached[]>> Get(
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<DailyLimitReached[]>();
        }

        public async Task<Result<SuccessfulDailyLimitReachedWebhookAdd>> Add(AddDailyLimitReachedWebhook request,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulDailyLimitReachedWebhookAdd>(requestUri, 
                data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulDailyLimitReachedWebhookRemove>> Remove(string id,
          AccessToken accessToken = default,
          CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpDelete<SuccessfulDailyLimitReachedWebhookRemove>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

        }

        public async Task<Result<SuccessfulDailyLimitReachedWebhookTest>> Test(
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var fullPath = $"{path}/test";

            var requestUri = GetUri(fullPath);

           return await HttpPost<SuccessfulDailyLimitReachedWebhookTest>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

    }
}
