﻿using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class SuccessfulDomainWhitelist
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
