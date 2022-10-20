using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulPaymentMethods
    {
        [JsonProperty("payment_methods")]
        public PaymentMethod[] PaymentMethods { get; set; } = new PaymentMethod[0];
    }

}
