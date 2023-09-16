using Newtonsoft.Json;

namespace GetAddress
{
    public class AddPrivateAddress
    {
        
        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        
        [JsonProperty("line_1")]
        public string Line1 { get; set; }

        
        [JsonProperty("line_2")]
        public string Line2 { get; set; }

        
        [JsonProperty("line_3")]
        public string Line3 { get; set; }

        
        [JsonProperty("line_4")]
        public string Line4 { get; set; }

        
        [JsonProperty("residential")]
        public bool Residential { get; set; }

        
        [JsonProperty("locality")]
        public string Locality { get; set; }

        
        [JsonProperty("town_or_city")]
        public string TownOrCity { get; set; }

        
        [JsonProperty("county")]
        public string County { get; set; }
    }
}
