using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Sdk.Tests
{
    public class FindTests
    {
        [Fact]
        public async Task Given_Known_Postcode_Find_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Find("TR19 7AA");

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Known_Postcode_And_HouseName_Find_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Find("TR19 7AA", new FindOptions { HouseNameOrNumber = "Lands End" });

            result.IsSuccess.ShouldBeTrue();
        }
    }
}
