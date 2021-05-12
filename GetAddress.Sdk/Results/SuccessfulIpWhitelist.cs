using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulIpAddressWhitelist
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

}
