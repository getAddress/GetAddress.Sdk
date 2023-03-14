using Newtonsoft.Json;


namespace GetAddress
{
    public class Suggestion
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

    }

    public class SuggestionAndDistance: Suggestion
    {
        [JsonProperty("distance")]
        public string Distance { get; set; }
    }


}
