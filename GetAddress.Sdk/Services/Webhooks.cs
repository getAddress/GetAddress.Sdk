﻿using System.Net.Http;

namespace GetAddress.Services
{
    public class Webhooks
    {
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

        public Webhooks(AdministrationKey administrationKey, HttpClient httpClient = null)
        {
            DailyLimitReached = new DailyLimitedReachedWebhookService(administrationKey, httpClient: httpClient);
            MonthlyReserveReached = new MonthlyReserveReachedWebhookService(administrationKey, httpClient: httpClient);
            PaymentFailed = new PaymentFailedWebhookService(administrationKey, httpClient: httpClient);
            Expired = new ExpiredWebhookService(administrationKey, httpClient: httpClient);
        }
    }
}
