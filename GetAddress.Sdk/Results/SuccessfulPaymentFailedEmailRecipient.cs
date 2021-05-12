using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulPaymentFailedEmailRecipient
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
