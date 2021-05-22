using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulAdd
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("id")]
        public string Id{ get; set; }
    }

    public class SuccessfulSuggestLimitReachedWebhookAdd : SuccessfulAdd
    {

    }

    public class SuccessfulTrackWebhookAdd : SuccessfulAdd
    {

    }

    public class SuccessfulPaymentCardAdd
    {

    }

    public class SuccessfulPaymentFailedWebhookAdd : SuccessfulAdd
    {

    }

    public class SuccessfulMonthlyReserveReachedWebhookAdd : SuccessfulAdd
    {

    }

    public class SuccessfulDailyLimitReachedWebhookAdd : SuccessfulAdd
    {

    }

    public class SuccessfulExpiredWebhookAdd : SuccessfulAdd
    {

    }

    public class SuccessfulInvoiceEmailRecipientAdd: SuccessfulAdd
    {

    }

    public class SuccessfulExpiredEmailRecipientAdd : SuccessfulAdd
    {

    }

    public class SuccessfulDailyLimitReachedEmailRecipientAdd : SuccessfulAdd
    {

    }

    public class SuccessfulMonthlyReserveReachedEmailRecipientAdd : SuccessfulAdd
    {

    }

    public class SuccessfulPaymentFailedReachedEmailRecipientAdd : SuccessfulAdd
    {

    }

    public class SuccessfulDomainWhitelistAdd : SuccessfulAdd
    {

    }

    public class SuccessfulIpAddressWhitelistAdd : SuccessfulAdd
    {

    }
}
