using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class AddExpiredEmailRecipient
    {
        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
