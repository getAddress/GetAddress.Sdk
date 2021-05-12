using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulDailyLimitReachedEmailRecipient
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
