using System.Net.Http;

namespace GetAddress.Sdk.Services
{
    public class EmailNotifications
    {
        public ExpiredEmailRecipientService Expired
        {
            get;
        }

        public InvoiceEmailRecipientService Invoice
        {
            get;
        }

        public DailyLimitedReachedEmailRecipientService DailyLimitedReached
        {
            get;
        }

        public MonthlyReserveReachedEmailRecipientService MonthlyReserveReached
        {
            get;
        }

        public EmailNotifications(string administrationKey, HttpClient httpClient = null)
        {
            Expired = new  ExpiredEmailRecipientService(administrationKey, httpClient: httpClient);
            Invoice = new InvoiceEmailRecipientService(administrationKey, httpClient: httpClient);
            DailyLimitedReached = new DailyLimitedReachedEmailRecipientService(administrationKey, httpClient: httpClient);
            MonthlyReserveReached = new MonthlyReserveReachedEmailRecipientService(administrationKey, httpClient: httpClient);
        }
    }
}
