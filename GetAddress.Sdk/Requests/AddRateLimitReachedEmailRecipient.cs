using Newtonsoft.Json;

namespace GetAddress
{
    public class AddRateLimitReachedEmailRecipient
    {
        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
