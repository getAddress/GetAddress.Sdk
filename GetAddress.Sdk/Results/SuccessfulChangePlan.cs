using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulChangePlan
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
