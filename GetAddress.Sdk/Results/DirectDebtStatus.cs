using Newtonsoft.Json;

namespace GetAddress
{
    public class DirectDebtStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
