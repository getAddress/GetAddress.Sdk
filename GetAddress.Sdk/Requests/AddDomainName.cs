using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class AddDomainName
    {
        [JsonProperty("name")]
        public string DomainName { get; set; }
    }
}
