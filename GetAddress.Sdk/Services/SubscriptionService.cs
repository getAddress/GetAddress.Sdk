using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class SubscriptionService : AdministrationService
    {
        private const string path = "subscription";
        private const string v2Path = "v2/subscription";
        public SubscriptionService(AdministrationKey administrationKey, HttpClient httpClient = null) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<Subscription>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(v2Path);

            return await HttpGet<Subscription>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulUnsubscribe>> Unsubscribe(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var nameValues = new NameValueCollection();

            nameValues.Add("api-version", "2020-09-09");

            var requestUri = GetUri(v2Path, nameValueCollection: nameValues);

            return await HttpPut<SuccessfulUnsubscribe>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulChangePlan>> ChangePlan(ChangePlan request, AccessToken accessToken = default, 
            CancellationToken cancellationToken = default)
        {
            var nameValues = new NameValueCollection();

            nameValues.Add("api-version", "2020-09-09");

            var fullPath = v2Path + "subscription/change-plan";

            var requestUri = GetUri(fullPath, nameValueCollection: nameValues);

            return await HttpPut<SuccessfulChangePlan>(requestUri, data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulSubscriptionUpdate>> Update(UpdateSubscription request, AccessToken accessToken = default,
           CancellationToken cancellationToken = default)
        {
            var nameValues = new NameValueCollection();

            nameValues.Add("api-version", "2020-09-09");

            var requestUri = GetUri(path, nameValueCollection: nameValues);

            return await HttpPut<SuccessfulSubscriptionUpdate>(requestUri, data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulCreateSubscription>> Create(CreateSubscription request, AccessToken accessToken = default,
          CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulCreateSubscription>(requestUri, data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

    }
}
