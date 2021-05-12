using Newtonsoft.Json;
using System;

namespace GetAddress
{

    public class Usage
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("usage_today")]
        public int UsageToday { get; set; }

        [JsonProperty("daily_limit")]
        public int DailyLimit { get; set; }

        [JsonProperty("monthly_buffer")]
        public int MonthlyBuffer { get; set; }

        [JsonProperty("monthly_buffer_used")]
        public int MonthlyBufferUsed { get; set; } 
    }

}
