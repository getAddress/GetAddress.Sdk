using Newtonsoft.Json;

namespace GetAddress
{
    public class AddPaymentFailedEmailRecipient
    {
        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
