using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace GetAddress.Sdk
{
   
    internal static class HttpClientExtensions
    {
        public  static HttpClient SetBaseAddress(this HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.getaddress.io/");
            return client;
        }

        public static void ClearAuthorization(this HttpClient client)
        {
            if (client.DefaultRequestHeaders.Contains("Authorization"))
            {
                client.DefaultRequestHeaders.Remove("Authorization");
            }
        }

        private static void SetAuthorization(this HttpClient client, string scheme, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);
        }

        public static void SetBearerToken(this HttpClient client, string token)
        {
            client.SetAuthorization("Bearer", token);
        }

        public static void SetApiKeyAuthorization(this HttpClient client, string administratorOrApikey)
        {
            client.SetAuthorization("api-key", administratorOrApikey);
        }
    }
}
