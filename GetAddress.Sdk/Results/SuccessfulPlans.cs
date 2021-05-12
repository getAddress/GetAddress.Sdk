using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulPlans
    {
        [JsonProperty("plans")]
        public Plan[] Plans { get; set; }
    }
}
