using Newtonsoft.Json;
using System;


namespace GetAddress.Sdk
{
    
    public class Tokens
    {
        [JsonProperty("access")]
        public AccessToken Access { get; set; }

        [JsonProperty("refresh")]
        public RefreshToken Refresh { get; set; }
    }

    public class Token
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public class AccessToken:Token
    {
        [JsonProperty("expires")]
        public DateTime Expires { get; set; }
    }
    public class RefreshToken:Token
    {
        [JsonProperty("expires")]
        public DateTime Expires { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

}
