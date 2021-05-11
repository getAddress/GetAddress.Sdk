using System.Net.Http;

namespace GetAddress.Sdk.Services
{
    public class Webhooks
    {
        public DailyLimitedReachedWebhookService DailyLimitReached
        {
            get;
        }

        public Webhooks(string administrationKey, HttpClient httpClient = null)
        {
            DailyLimitReached = new DailyLimitedReachedWebhookService(administrationKey, httpClient: httpClient);
        }
    }
}
