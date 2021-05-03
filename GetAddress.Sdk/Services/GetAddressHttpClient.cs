using System;
using System.Net.Http;

namespace GetAddress.Sdk.Services
{
    internal class GetAddressHttpClient:HttpClient
    {
        public GetAddressHttpClient()
        {
            this.BaseAddress = new Uri("https://api.getaddress.io/"); 
        }

    }
}
