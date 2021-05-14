using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulPaymentCardUpdate
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
