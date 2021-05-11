using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulCreateSubscription
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
