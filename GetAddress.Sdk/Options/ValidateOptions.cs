using Newtonsoft.Json;

namespace GetAddress
{
    public class ValidateOptions : Options
    {
        [JsonProperty("strict")]
        public bool? Strict { get; set; } = null;

        [JsonProperty("residential")]
        public bool? Residential { get; set; } = null;
    }

}
