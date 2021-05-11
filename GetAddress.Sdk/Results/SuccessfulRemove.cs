using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulRemove
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class SuccessfulInvoiceEmailRecipientRemove: SuccessfulRemove
    {

    }

    public class SuccessfulExpiredEmailRecipientRemove : SuccessfulRemove
    {

    }

    public class SuccessfulMonthlyReserveReachedWebhookRemove : SuccessfulRemove
    {

    }

    public class SuccessfulDailyLimitReachedWebhookRemove : SuccessfulRemove
    {

    }

    public class SuccessfulDailyLimitReachedEmailRecipientRemove : SuccessfulRemove
    {

    }

    public class SuccessfulMonthlyReserveReachedEmailRecipientRemove : SuccessfulRemove
    {

    }

    public class SuccessfulPaymentFailedReachedEmailRecipientRemove : SuccessfulRemove
    {

    }

    public class SuccessfulDomainWhitelistRemove : SuccessfulRemove
    {

    }

    public class SuccessfulIpAddressWhitelistRemove : SuccessfulRemove
    {

    }
}
