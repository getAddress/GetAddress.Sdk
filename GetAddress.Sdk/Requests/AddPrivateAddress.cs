using Newtonsoft.Json;

namespace GetAddress
{
    public class AddPrivateAddress
    {
        [JsonProperty("line1")]
        public string Line1 { get; set; }

        [JsonProperty("line2")]
        public string Line2 { get; set; }

        [JsonProperty("line3")]
        public string Line3 { get; set; }

        [JsonProperty("line4")]
        public string Line4 { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("townOrCity")]
        public string TownOrCity { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }
    }
}
