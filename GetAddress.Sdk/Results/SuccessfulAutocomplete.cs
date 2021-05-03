using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulAutocomplete
    {
        [JsonProperty("suggestions")]
        public Suggestion[] Suggestions { get; set; } = new Suggestion[0];
    }
}
