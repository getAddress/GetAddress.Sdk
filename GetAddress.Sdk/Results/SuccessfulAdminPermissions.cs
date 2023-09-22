using Newtonsoft.Json;
using System;

namespace GetAddress
{
    public class SuccessfulAdminPermissions
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("expires")]
        public DateTime Expires { get; set; }

        [JsonProperty("permissions")]
        public AdminPermissions Permissions { get; set; } = new AdminPermissions();
    }

    public class AdminPermissions
    {
        [JsonProperty("view_invoices")]
        public bool ViewInvoices { get; set; }

        [JsonProperty("view_security")]
        public bool ViewSecurity { get; set; }

        [JsonProperty("can_unsubscribe")]
        public bool CanUnsubscribe { get; set; }

        [JsonProperty("view_payment_methods")]
        public bool ViewPaymentMethods { get; set; }

        [JsonProperty("view_monitor")]
        public bool ViewMonitor { get; set; }

        [JsonProperty("view_billing_address")]
        public bool ViewBillingAddress { get; set; }

        [JsonProperty("can_upgrade")]
        public bool CanUpgrade { get; set; }

        [JsonProperty("create_subscription")]
        public bool CreateSubscription { get; set; }

        [JsonProperty("view_notifications")]
        public bool ViewNotifications { get; set; }

        [JsonProperty("addresses")]
        public bool Addresses { get; set; }
    }


}
