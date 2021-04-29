using System;
using System.Collections.Generic;
using System.Text;

namespace GetAddress.Sdk.Tests
{
    public static class Helpers
    {
        public static class UrlHelper
        {
            public static Uri GetTestServerUri()
            {
                var url = Environment.GetEnvironmentVariable("getaddress_staging_url", EnvironmentVariableTarget.User);

                if (string.IsNullOrWhiteSpace(url)) throw new Exception("Add your staging url to your Environmental Variables");

                return new Uri(url);
            }
        }

        public static class KeyHelper
        {
            public static string GetAdminKey()
            {
                var adminKey = Environment.GetEnvironmentVariable("getaddress_adminkey", EnvironmentVariableTarget.User);

                if (string.IsNullOrWhiteSpace(adminKey)) throw new Exception("Add your admin key to your Environmental Variables");

                return adminKey;
            }

            public static string GetApiKey()
            {
                var apiKey = Environment.GetEnvironmentVariable("getaddress_apikey", EnvironmentVariableTarget.User);

                if (string.IsNullOrWhiteSpace(apiKey)) throw new Exception("Add your api key to your Environmental Variables");

                return apiKey;
            }

            public static string GetExpiredApiKey()
            {
                var apiKey = Environment.GetEnvironmentVariable("getaddress_expired_apikey", EnvironmentVariableTarget.User);

                if (string.IsNullOrWhiteSpace(apiKey)) throw new Exception("Add your api key to your Environmental Variables");

                return apiKey;
            }

           

            
        }

    }
}
