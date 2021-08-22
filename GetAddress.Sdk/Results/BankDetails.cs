using Newtonsoft.Json;

namespace GetAddress
{
    public class BankDetails
    {
        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("account_holder_name")]
        public string AccountHolderName { get; set; }

        [JsonProperty("account_number_ending")]
        public string AccountNumberEnding { get; set; }
    }
}
