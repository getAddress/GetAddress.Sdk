﻿using Newtonsoft.Json;

namespace GetAddress
{
    public class SuccessfulAuth
    {
        [JsonProperty("tokens")]
        public Tokens Tokens { get; set; }
    }
}
