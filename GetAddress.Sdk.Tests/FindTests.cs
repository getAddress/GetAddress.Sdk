using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Sdk.Tests
{
    public class FindTests
    {
        public GetAddressApi GetApi()
        {
            var apiKey = Helpers.KeyHelper.GetApiKey();

            var adminKey = Helpers.KeyHelper.GetAdminKey();

            var testServerUri = Helpers.UrlHelper.GetTestServerUri();

            var api = new GetAddressApi(apiKey, adminKey);
            api.BaseAddress = testServerUri;

            return api;
        }

        [Fact]
        public async Task Given_Known_Postcode_Find_Returns_Successful_Result()
        {
            var api = GetApi();

            var result = await api.Find("TR19 7AA");

            result.IsSuccess.ShouldBeTrue();
        }
    }
}
