using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulDistance
    {
        [JsonProperty("from")]
        public Point From { get; set; } = new Point();

        [JsonProperty("to")]
        public Point To { get; set; } = new Point();

        [JsonProperty("metres")]
        public double Metres { get; set; }

    }

    public class Point
    {
        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

}
