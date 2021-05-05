using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class AddPaymentFailedEmailRecipient
    {
        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
