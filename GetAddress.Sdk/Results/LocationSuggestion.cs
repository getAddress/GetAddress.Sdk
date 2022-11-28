using Newtonsoft.Json;

namespace GetAddress
{
    public class LocationSuggestion
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

    }
}
