using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulRemove
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class SuccessfulDomainTokenRemove : SuccessfulRemove
    {

    }

   

    public class SuccessfulSuggestLimitReachedWebhookRemove : SuccessfulRemove
    {

    }

    public class SuccessfulTrackWebhookRemove : SuccessfulRemove
    {

    }
    public class SuccessfulPaymentCardRemove : SuccessfulRemove
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

    

    public class SuccessfulMonthlyReserveReachedWebhookRemove : SuccessfulRemove
    {

    }

    public class SuccessfulDailyLimitReachedWebhookRemove : SuccessfulRemove
    {

    }

    public class SuccessfulExpiredWebhookRemove : SuccessfulRemove
    {

    }
    public class SuccessfulLoginRequestedWebhookRemove : SuccessfulRemove
    {

    }

    public class SuccessfulDailyLimitReachedEmailRecipientRemove : SuccessfulRemove
    {

    }

    public class SuccessfulRateLimitReachedEmailRecipientRemove : SuccessfulRemove
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

    public class SuccessfulAdminPermissionRemove : SuccessfulRemove
    {

    }
}
