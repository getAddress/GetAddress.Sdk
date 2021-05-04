using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulRemove
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class SuccessfulInvoiceEmailRecipientRemove: SuccessfulRemove
    {

    }

    public class SuccessfulExpiredEmailRecipientRemove : SuccessfulRemove
    {

    }
}
