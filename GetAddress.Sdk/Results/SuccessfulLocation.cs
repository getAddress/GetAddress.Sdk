using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulLocation
    {
        [JsonProperty("suggestions")]
        public LocationSuggestion[] Suggestions { get; set; } = new LocationSuggestion[0];
    }
}
