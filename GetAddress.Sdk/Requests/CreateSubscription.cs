using Newtonsoft.Json;

namespace GetAddress
{
    public class CreateSubscription
    {
        [JsonProperty("plan_name")]
        public string PlanName
        {
            get; set;
        }

        [JsonProperty("card_id")]
        public string CardId
        {
            get; set;
        }
    }
}
