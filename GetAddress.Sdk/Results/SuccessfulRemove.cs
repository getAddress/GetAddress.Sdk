using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulRemove
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class SuccessfulPaymentCardRemove : SuccessfulRemove
    {

    }

    public class SuccessfulDailyLimitReachedWebhookTest : SuccessfulRemove
    {

    }

    public class SuccessfulInvoiceEmailRecipientRemove: SuccessfulRemove
    {

    }

    public class SuccessfulExpiredEmailRecipientRemove : SuccessfulRemove
    {

    }

    public class SuccessfulPaymentFailedWebhookRemove : SuccessfulRemove
    {

    }

    public class SuccessfulPaymentFailedWebhookTest : SuccessfulRemove
    {

    }

    public class SuccessfulMonthlyReserveReachedWebhookRemove : SuccessfulRemove
    {

    }

    public class SuccessfulMonthlyReserveReachedWebhookTest : SuccessfulRemove
    {

    }

    public class SuccessfulDailyLimitReachedWebhookRemove : SuccessfulRemove
    {

    }

    public class SuccessfulExpiredWebhookRemove : SuccessfulRemove
    {

    }

    public class SuccessfulExpiredWebhookTest : SuccessfulRemove
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
