using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class AddDailyLimitReachedEmailRecipient
    {
        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
