using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class UpdateSubscriptionRequest
    {
        [JsonProperty("name")]
        public string Name
        {
            get; set;
        }
    }
}
