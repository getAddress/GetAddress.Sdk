using Newtonsoft.Json;

namespace GetAddress
{
    public class AddDomainToken
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("limit_minutes")]
        public int? LimitMinutes { get; set; }
    }
}
