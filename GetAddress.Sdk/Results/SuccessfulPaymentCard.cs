using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulPaymentCard
    {
        [JsonProperty("cards")]
        public PaymentCard[] Cards { get; set; } = new PaymentCard[0];
    }

}
