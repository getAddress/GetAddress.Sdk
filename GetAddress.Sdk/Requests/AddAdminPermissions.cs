using Newtonsoft.Json;
using System;

namespace GetAddress
{
    public class AddAdminPermissions
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("expires")]
        public DateTime? Expires { get; set; }

        [JsonProperty("permissions")]
        public AdminPermissions Permissions { get; set; } = new AdminPermissions();
    }
}
