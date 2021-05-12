using Newtonsoft.Json;

namespace GetAddress
{
    public class AddMonthlyReserveReachedEmailRecipient
    {
        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
