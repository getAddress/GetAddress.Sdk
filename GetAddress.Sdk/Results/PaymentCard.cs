using Newtonsoft.Json;


namespace GetAddress
{
    public class PaymentCard
    {
        [JsonProperty("month_expires")]
        public int MonthExpires { get; set; }

        [JsonProperty("year_expires")]
        public int YearExpires { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("last_four_digits")]
        public int LastFourDigits { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

    }
}
