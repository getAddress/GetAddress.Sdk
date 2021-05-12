using Newtonsoft.Json;

namespace GetAddress
{
    public class UpdateEmail
    {
        [JsonProperty("new-email-address")]
        public string NewEmailAddress { get; set; }
    }

}
