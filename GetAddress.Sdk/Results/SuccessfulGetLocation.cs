using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulGetLocation
    {
        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("outcode")]
        public string Outcode { get; set; }

        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("town_or_city")]
        public string TownOrCity { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

    }
}
