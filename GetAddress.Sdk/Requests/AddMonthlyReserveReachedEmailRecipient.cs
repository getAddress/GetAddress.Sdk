using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class AddMonthlyReserveReachedEmailRecipient
    {
        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
