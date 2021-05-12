using Newtonsoft.Json;

namespace GetAddress
{
    public class AddDailyLimitReachedEmailRecipient
    {
        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
