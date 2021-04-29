using Newtonsoft.Json;
using System;


namespace GetAddress.Sdk
{
    
    public class Tokens
    {
        [JsonProperty("access_token")]
        public AccessToken Access { get; set; }

        [JsonProperty("refresh_token")]
        public RefreshToken Refresh { get; set; }
    }

    public class AccessToken
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("expires")]
        public DateTime Expires { get; set; }
    }
    public class RefreshToken
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("expires")]
        public DateTime Expires { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

}
