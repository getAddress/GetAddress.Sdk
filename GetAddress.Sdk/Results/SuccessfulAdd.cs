using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulAdd
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("id")]
        public string Id{ get; set; }
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
}
