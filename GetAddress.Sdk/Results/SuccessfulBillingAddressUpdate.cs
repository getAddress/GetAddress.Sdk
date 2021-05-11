using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulBillingAddressUpdate
    {
        [JsonProperty("response_id")]
        public string ResponseId { get; set; }
    }
}
