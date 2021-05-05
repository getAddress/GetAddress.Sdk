using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class AddInvoiceEmailRecipient
    {
        [JsonProperty("email-address")]
        public string EmailAddress{ get; set; }
    }
}
