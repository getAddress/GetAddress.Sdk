using Newtonsoft.Json;

namespace GetAddress
{
    public class AutocompleteOptions : Options
    {
        [JsonProperty("top")]
        public int Top { get; set; }

        [JsonProperty("all")]
        public bool? All { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("client_ip_address")]
        public string ClientIpAddress { get; set; }

        [JsonProperty("filter")]
        public AutocompleteFilter Filter { get; set; } = new AutocompleteFilter();

        [JsonProperty("location")]
        public AutocompleteLocation Location { get; set; } = new AutocompleteLocation();
    }

    public class AutocompleteFilter
    {

        [JsonProperty("locality")]
        public string Locality
        {
            get; set;
        }


        [JsonProperty("district")]
        public string District
        {
            get; set;
        }

        [JsonProperty("county")]
        public string County
        {
            get; set;
        }

        [JsonProperty("thoroughfare")]
        public string Thoroughfare
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


        [JsonProperty("residential")]
        public bool? Residential { get; set; }

        [JsonProperty("radius")]
        public AutocompleteRadius Radius { get; set; } = new AutocompleteRadius();
    }

    public class AutocompleteRadius
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

    public class AutocompleteLocation
    {
        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }
    }

}
