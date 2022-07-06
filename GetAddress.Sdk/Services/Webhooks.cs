using System.Net.Http;

namespace GetAddress.Services
{
    public class Webhooks
    {

        public LoginRequestedWebhookService LoginRequested
        {
            get;
        }

        public DailyLimitedReachedWebhookService DailyLimitReached
        {
            get;
        }

        public MonthlyReserveReachedWebhookService MonthlyReserveReached
        {
            get;
        }

        public PaymentFailedWebhookService PaymentFailed
        {
            get;
        }

        public ExpiredWebhookService Expired
        {
            get;
        }

        public TrackWebhookService Track
        {
            get;
        }

        public SuggestLimitReachedWebhookService SuggestLimitReached
        {
            get;
        }

        public Webhooks(AdministrationKey administrationKey, HttpClient httpClient = null)
        {
            DailyLimitReached = new DailyLimitedReachedWebhookService(administrationKey, httpClient: httpClient);
            MonthlyReserveReached = new MonthlyReserveReachedWebhookService(administrationKey, httpClient: httpClient);
            PaymentFailed = new PaymentFailedWebhookService(administrationKey, httpClient: httpClient);
            Expired = new ExpiredWebhookService(administrationKey, httpClient: httpClient);
            Track = new TrackWebhookService(administrationKey, httpClient: httpClient);
            SuggestLimitReached = new SuggestLimitReachedWebhookService(administrationKey, httpClient: httpClient);
            LoginRequested = new LoginRequestedWebhookService(administrationKey, httpClient: httpClient);
        }
    }
}
