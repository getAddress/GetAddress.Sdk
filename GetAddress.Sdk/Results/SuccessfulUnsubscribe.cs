using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulUnsubscribe
    {
        [JsonProperty("response_id")]
        public string ResponseId { get; set; }
    }
}
