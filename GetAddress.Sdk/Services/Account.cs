using System.Net.Http;

namespace GetAddress.Services
{
    public class Account
    {
        public BillingAddressService BillingAddress
        {
            get;
        }

        public EmailService EmailAddress
        {
            get;
        }

        public PaymentCardService PaymentCard
        {
            get;
        }

        public Account(AdministrationKey administrationKey, HttpClient httpClient = null)
        {
            BillingAddress = new BillingAddressService(administrationKey, httpClient: httpClient);
            EmailAddress = new EmailService(administrationKey, httpClient: httpClient);
            PaymentCard = new PaymentCardService(administrationKey, httpClient: httpClient);
        }
    }
}