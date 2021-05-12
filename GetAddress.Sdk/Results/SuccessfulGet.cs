using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulGet:Address
    {
        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("residential")]
        public bool Residential { get; set; }
    }
}
