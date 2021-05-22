using Newtonsoft.Json;

namespace GetAddress
{
    public class SucessfulWebhookTest
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class SuccessfulPaymentFailedWebhookTest : SucessfulWebhookTest
    {

    }
    public class SuccessfulMonthlyReserveReachedWebhookTest : SucessfulWebhookTest
    {

    }
    public class SuccessfulExpiredWebhookTest : SucessfulWebhookTest
    {

    }
    public class SuccessfulDailyLimitReachedWebhookTest : SucessfulWebhookTest
    {

    }

    public class SuccessfulTrackWebhookTest : SucessfulWebhookTest
    {

    }

    public class SuccessfulSuggestLimitReachedWebhookTest : SucessfulWebhookTest
    {

    }
}
