using Newtonsoft.Json;

namespace GetAddress
{
    public class AddPaymentCard
    {
        [JsonProperty("token")]
        public string Token
        {
            get;
            set;
        }
    }
}
