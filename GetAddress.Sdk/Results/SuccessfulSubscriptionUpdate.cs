using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulSubscriptionUpdate
    {
        [JsonProperty("response_id")]
        public string ResponseId { get; set; }
    }
}
