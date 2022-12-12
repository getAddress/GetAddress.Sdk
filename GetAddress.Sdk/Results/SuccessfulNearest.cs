using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulNearest
    {
        [JsonProperty("suggestions")]
        public SuggestionAndDistance[] Suggestions { get; set; } = new SuggestionAndDistance[0];
    }
}
