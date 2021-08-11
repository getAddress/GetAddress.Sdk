using Newtonsoft.Json;

namespace GetAddress
{
    public class UpdateSubscription
    {
        [JsonProperty("name")]
        public string Name
        {
            get; set;
        }

        [JsonProperty("autoUpgrade")]
        public bool AutoUpgrade
        {
            get; set;
        }
    }
}
