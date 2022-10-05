using Shouldly;
using System;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{

    public class ApiKeyTests
    {
        [Fact]
        public async Task Get_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Security.ApiKey.Get();

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Update_Returns_New_ApiKey()
        {
            var api = Helpers.ApiHelper.GetApiWithUpdatableKeys();

            var result = await api.Security.ApiKey.Get();

            result.IsSuccess.ShouldBeTrue();

            var updateResult = await api.Security.ApiKey.Update();

            updateResult.IsSuccess.ShouldBeTrue();

            updateResult.Success.ApiKey.ShouldNotBe(result.Success.ApiKey);
        }

        

       
    }
}
