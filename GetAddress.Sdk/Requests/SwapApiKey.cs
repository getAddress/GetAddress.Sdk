using Newtonsoft.Json;
using System;

namespace GetAddress
{
    public class SwapApiKey
    {
        [JsonProperty("new_api_key")]
        public string NewApiKey { get; set; }
    }
}
