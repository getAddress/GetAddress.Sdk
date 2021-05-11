using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulSubscriptionUpdate
    {
        [JsonProperty("response_id")]
        public string ResponseId { get; set; }
    }
}
