using Newtonsoft.Json;

namespace GetAddress
{
    public class AddDomainName
    {
        [JsonProperty("name")]
        public string DomainName { get; set; }
    }
}
