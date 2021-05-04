using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class UpdateEmailRequest
    {
        [JsonProperty("new-email-address")]
        public string NewEmailAddress { get; set; }
    }
}
