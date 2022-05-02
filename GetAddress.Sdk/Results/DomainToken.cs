using Newtonsoft.Json;


namespace GetAddress
{
    public class DomainToken
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("limit_minutes")]
        public int? LimitMinutes { get; set; }
    }

}
