using Newtonsoft.Json;


namespace GetAddress
{
    public class Plan
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("daily_limit")]
        public int DailyLimit { get; set; }
    }

}
