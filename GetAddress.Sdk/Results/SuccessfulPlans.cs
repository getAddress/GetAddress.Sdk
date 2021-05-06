using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulPlans
    {
        [JsonProperty("plans")]
        public Plan[] Plans { get; set; }
    }
}
