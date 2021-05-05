using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulApiKeyUpdate
    {
        [JsonProperty("api-key")]
        public string ApiKey { get; set; }
    }
}
