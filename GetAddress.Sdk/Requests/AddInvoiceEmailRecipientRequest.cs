using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class AddInvoiceEmailRecipientRequest
    {
        [JsonProperty("email-address")]
        public string EmailAddress{ get; set; }
    }
}
