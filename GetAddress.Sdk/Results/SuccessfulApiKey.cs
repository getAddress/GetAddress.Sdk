using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulApiKey
    {
        [JsonProperty("api-key")]
        public string ApiKey { get; set; }
    }

}
