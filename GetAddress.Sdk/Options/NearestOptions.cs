using Newtonsoft.Json;

namespace GetAddress
{
    public class NearestOptions:Options
    {
        [JsonProperty("top")]
        public int Top { get; set; }

        [JsonProperty("radius")]
        public double Radius { get; set; }

        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }
    }

}
