using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulEmail
    {
        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
