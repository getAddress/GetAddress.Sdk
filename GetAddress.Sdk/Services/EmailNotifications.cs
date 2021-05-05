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

        public EmailNotifications(string administrationKey, HttpClient httpClient = null)
        {
            Expired = new  ExpiredEmailRecipientService(administrationKey, httpClient);
            Invoice = new InvoiceEmailRecipientService(administrationKey, httpClient);
        }
    }
}
