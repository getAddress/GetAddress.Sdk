using Newtonsoft.Json;
using System.Collections.Specialized;

namespace GetAddress
{
    public class AddWebhook
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class AddWebhookOptions
    {
        public string P256dh { get; set; }
        public string Auth { get; set; }

        internal NameValueCollection  GetNameValueCollectionOrDefault()
        {
            if (!string.IsNullOrEmpty(this.P256dh) && !string.IsNullOrEmpty(this.Auth))
            {
                var nameValueCollection = new NameValueCollection();
                nameValueCollection.Add(nameof(AddWebhookOptions.P256dh).ToLower(), this.P256dh);
                nameValueCollection.Add(nameof(AddWebhookOptions.Auth).ToLower(), this.Auth);
                return nameValueCollection;


            }
            return null;
        }

    }

    public class AddSuggestLimitReachedWebhook : AddWebhook
    {
        public AddWebhookOptions Options { get; set; }
    }

    public class AddTrackWebhook : AddWebhook
    {
        public AddWebhookOptions Options { get; set; }
    }

    public class AddLoginRequestedWebhook : AddWebhook
    {
        public AddWebhookOptions Options { get; set; }
    }

    public class AddExpiredWebhook : AddWebhook
    {
        public AddWebhookOptions Options { get; set; }
    }

    public class AddDailyLimitReachedWebhook: AddWebhook
    {
        public AddWebhookOptions Options { get; set; }
    }
    public class AddMonthlyReserveReachedWebhook : AddWebhook
    {
        public AddWebhookOptions Options { get; set; }
    }

    public class AddPaymentFailedWebhook : AddWebhook
    {
        public AddWebhookOptions Options { get; set; }
    }
}
