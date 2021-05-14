using Newtonsoft.Json;

namespace GetAddress
{
    public class UpdatePaymentCard
    {
        [JsonProperty("id")]
        public string DefaultCardId
        {
            get;
            set;
        }
    }
}
