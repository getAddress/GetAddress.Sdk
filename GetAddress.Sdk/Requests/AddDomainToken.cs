using Newtonsoft.Json;

namespace GetAddress
{
    public class AddDomainToken
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
