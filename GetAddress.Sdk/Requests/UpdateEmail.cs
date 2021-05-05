using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class UpdateEmail
    {
        [JsonProperty("new-email-address")]
        public string NewEmailAddress { get; set; }
    }
}
