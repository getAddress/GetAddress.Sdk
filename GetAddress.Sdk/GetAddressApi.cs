using System;
using System.Net.Http;

namespace GetAddress.Sdk
{
    public class GetAddressApi
    {
        private readonly HttpClient httpClient;
        
        public GetAddressApi(string apiKey, string administrationKey, HttpClient httpClient = null)
        {
            ApiKey = apiKey;
            AdministrationKey = administrationKey;
            this.httpClient = httpClient ?? GetHttpClient();
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = BaseAddress;

            return client;
        }

        public Uri BaseAddress
        {
            get;
            set;
        } = new Uri("https://api.getaddress.io");

        public string ApiKey { get; set; }
        public string AdministrationKey { get; set; }
    }
}
