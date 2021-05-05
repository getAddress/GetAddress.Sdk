using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class AddIpAddress
    {
        [JsonProperty("value")]
        public string IpAddress { get; set; }
    }
}
