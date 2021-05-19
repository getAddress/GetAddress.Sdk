using System.Net.Http;

namespace GetAddress.Services
{

    public class EmailNotifications
    {
        public PaymentFailedEmailRecipientService PaymentFailed
        {
            get;
        }

        public ExpiredEmailRecipientService Expired
        {
            get;
        }

        public InvoiceEmailRecipientService Invoice
        {
            get;
        }

        public DailyLimitReachedEmailRecipientService DailyLimitReached
        {
            get;
        }

        public MonthlyReserveReachedEmailRecipientService MonthlyReserveReached
        {
            get;
        }

        public EmailNotifications(AdministrationKey administrationKey, HttpClient httpClient)
        {
            Expired = new  ExpiredEmailRecipientService(administrationKey, httpClient: httpClient);
            Invoice = new InvoiceEmailRecipientService(administrationKey, httpClient: httpClient);
            DailyLimitReached = new DailyLimitReachedEmailRecipientService(administrationKey, httpClient: httpClient);
            MonthlyReserveReached = new MonthlyReserveReachedEmailRecipientService(administrationKey, httpClient: httpClient);
            PaymentFailed = new PaymentFailedEmailRecipientService(administrationKey, httpClient: httpClient);
        }
    }
}
