using Newtonsoft.Json;

namespace GetAddress
{
    public abstract class SuccessfulEmailRecipient
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
