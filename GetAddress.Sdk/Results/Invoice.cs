using Newtonsoft.Json;
using System;

namespace GetAddress
{
    public class Invoice
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("address_1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("address_2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("address_3")]
        public string AddressLine3 { get; set; }

        [JsonProperty("address_4")]
        public string AddressLine4 { get; set; }

        [JsonProperty("address_5")]
        public string AddressLine5 { get; set; }

        [JsonProperty("address_6")]
        public string AddressLine6 { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("tax")]
        public decimal Tax { get; set; }

        [JsonProperty("pdf_url")]
        public string Pdf { get; set; }

        [JsonProperty("invoice_lines")]
        public InvoiceLine[] Lines { get; set; } = new InvoiceLine[0];
    }

    public class InvoiceLine
    {
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("unit_price")]
        public decimal Price { get; set; }

        [JsonProperty("subtotal")]
        public decimal Subtotal { get; set; }
    }
}
