using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulEmail
    {
        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }
}
