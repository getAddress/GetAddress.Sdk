﻿using Newtonsoft.Json;

namespace GetAddress.Sdk
{
    public class AddWebhook
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
    public class AddDailyLimitReachedWebhook: AddWebhook
    {

    }

}