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


        [JsonProperty("attachInvoices")]
        public bool AttachInvoices
        {
            get; set;
        }
    }
}
