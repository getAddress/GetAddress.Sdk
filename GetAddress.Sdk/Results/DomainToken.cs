using Newtonsoft.Json;


namespace GetAddress
{
    public class DomainToken
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }
    }

}
