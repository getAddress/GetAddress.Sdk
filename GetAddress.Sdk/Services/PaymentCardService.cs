﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class PaymentCardService: AdministrationService
    {
        private const string path = "payment-card";
        public PaymentCardService(string administrationKey, HttpClient httpClient = null) : base(administrationKey, httpClient)
        {

        }

        public async Task<Result<SuccessfulPaymentCard>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulPaymentCard>();
        }

        public async Task<Result<SuccessfulPaymentCardRemove>> Remove(string id,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            var response = await HttpDelete(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulPaymentCardRemove>();
        }

        public async Task<Result<SuccessfulPaymentCardUpdate>> Update(UpdatePaymentCard request, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var content = request.ToHttpContent();

            var response = await HttpPut(requestUri, httpContent: content, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            var result = await response.ToResult<SuccessfulPaymentCardUpdate>();

            return result;
        }

        public async Task<Result<SuccessfulPaymentCardAdd>> Add(AddPaymentCard request, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var content = request.ToHttpContent();

            var response = await HttpPost(requestUri, httpContent: content, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulPaymentCardAdd>();

        }
    }
}
