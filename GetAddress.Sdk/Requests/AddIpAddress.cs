using Newtonsoft.Json;

namespace GetAddress
{
    public class AddIpAddress
    {
        [JsonProperty("value")]
        public string IpAddress { get; set; }
    }
}
