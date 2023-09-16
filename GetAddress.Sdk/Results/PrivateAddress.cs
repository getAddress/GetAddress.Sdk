using Newtonsoft.Json;


namespace GetAddress
{
    public class PrivateAddress
    {
        
            [JsonProperty("id")]
            public string Id { get; set; } = string.Empty;

            [JsonProperty("building_number")]
            public string BuildingNumber { get; set; } = string.Empty;

            [JsonProperty("building_name")]
            public string BuildingName { get; set; } = string.Empty;

            [JsonProperty("sub_building_number")]
            public string SubNumber { get; set; } = string.Empty;

            [JsonProperty("sub_building_name")]
            public string SubBuilding { get; set; } = string.Empty;

            [JsonProperty("thoroughfare")]
            public string Thoroughfare { get; set; } = string.Empty;

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("district")]
            public string District { get; set; }

            [JsonProperty("latitude")]
            public double Latitude { get; set; }

            [JsonProperty("longitude")]
            public double Longitude { get; set; }

            [JsonProperty("postcode")]
            public string Postcode { get; set; }

            [JsonProperty("line_1")]
            public string Line1 { get; set; }

            [JsonProperty("line_2")]
            public string Line2 { get; set; }

            
            [JsonProperty("line_3")]
            public string Line3 { get; set; }

            [JsonProperty("line_4")]
            public string Line4 { get; set; }

            [JsonProperty("residential")]
            public bool Residential { get; set; }

            
            [JsonProperty("locality")]
            public string Locality { get; set; }

            
            [JsonProperty("town_or_city")]
            public string TownOrCity { get; set; }

            
            [JsonProperty("county")]
            public string County { get; set; }

        
    }

}
