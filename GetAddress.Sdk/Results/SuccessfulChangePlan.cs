using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulChangePlan
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
