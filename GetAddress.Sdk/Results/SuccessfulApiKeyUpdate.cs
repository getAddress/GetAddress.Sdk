using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulApiKeyUpdate
    {
        [JsonProperty("api-key")]
        public string ApiKey { get; set; }
    }
}
