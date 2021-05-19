using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GetAddress.Tests
{
    public static class Helpers
    {

        public static class ApiHelper
        {
            public static Api GetApi()
            {
                var apiKey = Helpers.KeyHelper.GetApiKey();

                var adminKey = Helpers.KeyHelper.GetAdminKey();

                var testServerUri = Helpers.UrlHelper.GetTestServerUri();

                var httpClient = new HttpClient();
                httpClient.BaseAddress = testServerUri;

                var api = new Api(new ApiKeys(apiKey,adminKey), httpClient: httpClient);
                
                return api;
            }

            public static Api GetApiNoKeys()
            {

                var testServerUri = Helpers.UrlHelper.GetTestServerUri();

                var httpClient = new HttpClient();
                httpClient.BaseAddress = testServerUri;

                var api = new Api(new ApiKeys("", ""), httpClient: httpClient);

                return api;
            }

            public static Api GetApiWithUpdatableKeys()
            {
                var adminKey = Helpers.KeyHelper.GetUpdatableAdminKey();

                var testServerUri = Helpers.UrlHelper.GetTestServerUri();

                var httpClient = new HttpClient();
                httpClient.BaseAddress = testServerUri;

                var api = new Api(new ApiKeys("", adminKey), httpClient: httpClient);

                return api;
            }

            public static Api GetApiWithDomainWhitelistKeys()
            {
                var adminKey = Helpers.KeyHelper.GetDomainWhitelistAdminKey();

                var testServerUri = Helpers.UrlHelper.GetTestServerUri();

                var httpClient = new HttpClient();
                httpClient.BaseAddress = testServerUri;

                var api = new Api(new ApiKeys("", adminKey), httpClient: httpClient);

                return api;
            }

            public static Api GetApiWithIpAddressWhitelistKeys()
            {
                var adminKey = Helpers.KeyHelper.GetIpAddressWhitelistAdminKey();

                var testServerUri = Helpers.UrlHelper.GetTestServerUri();

                var httpClient = new HttpClient();
                httpClient.BaseAddress = testServerUri;

                var api = new Api(new ApiKeys("", adminKey), httpClient: httpClient);

                return api;
            }

        }
        public static class UrlHelper
        {
            public static Uri GetTestServerUri()
            {
               // return new Uri("https://localhost:44356/");

                var url = Environment.GetEnvironmentVariable("getaddress_test_url", EnvironmentVariableTarget.User);

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

            public static string GetUpdatableAdminKey()
            {
                var adminKey = Environment.GetEnvironmentVariable("getaddress_updatable_adminkey", EnvironmentVariableTarget.User);

                if (string.IsNullOrWhiteSpace(adminKey)) throw new Exception("Add your admin key to your Environmental Variables");

                return adminKey;
            }

            public static string GetDomainWhitelistAdminKey()
            {
                var adminKey = Environment.GetEnvironmentVariable("getaddress_domain_whitelist_adminkey", EnvironmentVariableTarget.User);

                if (string.IsNullOrWhiteSpace(adminKey)) throw new Exception("Add your admin key to your Environmental Variables");

                return adminKey;
            }

            public static string GetIpAddressWhitelistAdminKey()
            {
                var adminKey = Environment.GetEnvironmentVariable("getaddress_ipaddress_whitelist_adminkey", EnvironmentVariableTarget.User);

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
