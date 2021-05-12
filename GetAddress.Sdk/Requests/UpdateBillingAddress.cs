using Newtonsoft.Json;

namespace GetAddress
{
    public class UpdateBillingAddress
    {
        [JsonProperty("line1")]
        public string Line1
        {
            get;
            set;
        }
        [JsonProperty("line2")]
        public string Line2
        {
            get;
            set;
        }
        [JsonProperty("line3")]
        public string Line3
        {
            get;
            set;
        }

        [JsonProperty("townOrCity")]
        public string TownOrCity { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }
    }
}
