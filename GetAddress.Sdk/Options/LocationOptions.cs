using Newtonsoft.Json;

namespace GetAddress
{

    public class LocationOptions : Options
    {
        [JsonProperty("top")]
        public int Top { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("template_outcode")]
        public string TemplateOutcode { get; set; }

        [JsonProperty("template_postcode")]
        public string TemplatePostcode{ get; set; }

        [JsonProperty("client_ip_address")]
        public string ClientIpAddress { get; set; }

        [JsonProperty("filter")]
        public LocationFilter Filter { get; set; } = new LocationFilter();

        [JsonProperty("location")]
        public LocationLocation Location { get; set; } = new LocationLocation();
    }

    public class LocationFilter
    {

        [JsonProperty("area")]
        public string Area
        {
            get; set;
        }


        [JsonProperty("country")]
        public string Country
        {
            get; set;
        }


        [JsonProperty("county")]
        public string County
        {
            get; set;
        }


        [JsonProperty("town_or_city")]
        public string TownOrCity
        {
            get; set;
        }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }


        [JsonProperty("outcode")]
        public string Outcode { get; set; }


        [JsonProperty("radius")]
        public LocationRadius Radius { get; set; } = new LocationRadius();
    }

    public class LocationRadius
    {

        [JsonProperty("km")]
        public int? Km
        {
            get; set;
        }

        [JsonProperty("latitude")]
        public double? Latitude
        {
            get; set;
        }

        [JsonProperty("longitude")]
        public double? Longitude
        {
            get; set;
        }

    }

    public class LocationLocation
    {
        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }
    }

}
