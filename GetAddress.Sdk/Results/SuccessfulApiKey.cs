using Newtonsoft.Json;


namespace GetAddress
{
    public class SuccessfulApiKey
    {
        [JsonProperty("api-key")]
        public string ApiKey { get; set; }
    }

}
