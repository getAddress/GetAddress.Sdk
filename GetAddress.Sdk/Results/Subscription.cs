using Newtonsoft.Json;
using System;


namespace GetAddress
{
    public class Subscription
    {
        [JsonProperty("next_billing_date")]
        public DateTime NextBillingDate { get; set; }

        [JsonProperty("plan")]
        public PlanSummary Plan { get; set; } = new PlanSummary();

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("auto_upgrade")]
        public bool AutoUpgrade { get; set; }

        [JsonProperty("attach_invoices")]
        public bool AttachInvoices { get; set; }
    }
    public class PlanSummary
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("term")]
        public string Term { get; set; }
        
        [JsonProperty("daily_lookup_limit_1")]
        public int DailyLookupLimit1 { get; set; }

        [JsonProperty("daily_lookup_limit_2")]
        public int DailyLookupLimit2 { get; set; }

        [JsonProperty("multi_application")]
        public bool MultiApplication { get; set; }

    }

}
