using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulNearestLocation
    {
        [JsonProperty("suggestions")]
        public LocationSuggestionAndDistance[] Suggestions { get; set; } = new LocationSuggestionAndDistance[0];
    }
}
