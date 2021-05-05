using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulDailyLimitReachedEmailRecipient
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
