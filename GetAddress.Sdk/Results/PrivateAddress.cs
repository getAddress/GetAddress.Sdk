using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetAddress
{
    public class PrivateAddress
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("line1")]
        public string Line1 { get; set; }

        [JsonProperty("line2")]
        public string Line2 { get; set; }

        [JsonProperty("line3")]
        public string Line3 { get; set; }

        [JsonProperty("line4")]
        public string Line4 { get; set; }

        [JsonProperty("locality")] 
        public string Locality { get; set; }

        [JsonProperty("townOrcity")] 
        public string TownOrCity { get; set; }

        [JsonProperty("county")] 
        public string County { get; set; }
    }
}
