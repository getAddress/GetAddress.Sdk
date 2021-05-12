using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulCreateSubscription
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
