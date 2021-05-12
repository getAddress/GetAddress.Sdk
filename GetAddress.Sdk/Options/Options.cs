using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GetAddress
{
    public abstract class Options
    {
        [JsonIgnore]
        public string Version { get; set; } = $"2020-09-09";

    }
}
