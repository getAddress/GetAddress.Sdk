using Newtonsoft.Json;

namespace GetAddress
{
    public class AddExpiredEmailRecipient
    {
        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
