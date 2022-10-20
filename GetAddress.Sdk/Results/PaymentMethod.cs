using Newtonsoft.Json;


namespace GetAddress
{
    public class PaymentMethod
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

    }
}
