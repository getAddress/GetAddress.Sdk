using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulFind
    {
        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("addresses")]
        public Address[] Addresses { get; set; } = new Address[0];
    }
}
