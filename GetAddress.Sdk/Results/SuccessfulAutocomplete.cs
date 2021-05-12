using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulAutocomplete
    {
        [JsonProperty("suggestions")]
        public Suggestion[] Suggestions { get; set; } = new Suggestion[0];
    }
}
