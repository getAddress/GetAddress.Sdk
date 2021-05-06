using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulUnsubscribe
    {
        [JsonProperty("response_id")]
        public string ResponseId { get; set; }
    }
}
