using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public abstract class EmailRecipient
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }

    public class InvoiceEmailRecipient : EmailRecipient
    {

    }

}
