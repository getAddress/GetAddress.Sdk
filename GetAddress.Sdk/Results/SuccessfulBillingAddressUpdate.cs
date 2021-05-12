using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulBillingAddressUpdate
    {
        [JsonProperty("response_id")]
        public string ResponseId { get; set; }
    }
}
