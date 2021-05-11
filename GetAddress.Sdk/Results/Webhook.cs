using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class Webhook
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
    public class DailyLimitReached : Webhook
    {

    }

    public class MonthlyReserveReached : Webhook
    {

    }
}
