using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulAuth
    {
        [JsonProperty("tokens")]
        public Tokens Tokens { get; set; }
    }
}
