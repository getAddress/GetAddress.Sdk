using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class UpdateSubscription
    {
        [JsonProperty("name")]
        public string Name
        {
            get; set;
        }
    }
}
