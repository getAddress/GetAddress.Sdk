using System;
using System.Net.Http;

namespace GetAddress.Sdk.Services
{
    public abstract class Service
    {
        protected readonly HttpClient httpClient;

        protected Service(HttpClient httpClient = null)
        {
            this.httpClient = httpClient ?? new HttpClient();
        }

        public Uri BaseAddress
        {
            get;
            set;
        } = new Uri("https://api.getaddress.io/");

    }

    public abstract class AdministrationService:Service
    {
        public string AdministrationKey { get; set; }

        public AdministrationService(string administrationKey, HttpClient httpClient = null) : base(httpClient)
        {
            AdministrationKey = administrationKey;
        }
    }

    public abstract class ApiKeyService : Service
    {
        public string ApiKey { get; set; }

        public ApiKeyService(string apiKey, HttpClient httpClient = null) : base(httpClient)
        {
            ApiKey = apiKey;
        }
    }

}
