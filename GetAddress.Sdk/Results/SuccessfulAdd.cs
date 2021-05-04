using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulAdd
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("id")]
        public string Id{ get; set; }
    }

    public class SuccessfulInvoiceEmailRecipientAdd: SuccessfulAdd
    {

    }

    public class SuccessfulExpiredEmailRecipientAdd : SuccessfulAdd
    {

    }
}
