using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class AddExpiredEmailRecipientRequest
    {
        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
