using Newtonsoft.Json;

namespace GetAddress
{
    public class AddInvoiceEmailRecipient
    {
        [JsonProperty("email-address")]
        public string EmailAddress{ get; set; }
    }
}
