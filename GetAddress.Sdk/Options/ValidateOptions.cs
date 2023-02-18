using Newtonsoft.Json;

namespace GetAddress
{
    public class ValidateOptions : Options
    {
        [JsonProperty("strict")]
        public bool Strict { get; set; } = true;
    }

}
