using Newtonsoft.Json;

namespace GetAddress
{
    public class Webhook
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }


    public class SuggestLimitReached : Webhook
    {

    }

    public class Track : Webhook
    {

    }

    public class DailyLimitReached : Webhook
    {

    }

    public class Expired : Webhook
    {

    }


    public class MonthlyReserveReached : Webhook
    {

    }

    public class PaymentFailed : Webhook
    {

    }
}
