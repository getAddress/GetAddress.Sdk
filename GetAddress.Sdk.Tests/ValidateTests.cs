using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class ValidateTests
    {

        [Fact]
        public async Task Given_Known_Address_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Validate("10 Downing Street London SW1A 2AA");

            result.IsSuccess.ShouldBeTrue();
        }


        [Fact]
        public async Task Given_Known_Address_Returns_Successful_Result2()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Validate("28b pe15 0sr");

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Known_Address_Returns_Successful_Result3()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Validate("28b pe15 0sr", new ValidateOptions { Residential = true });

            result.IsSuccess.ShouldBeTrue();
        }
    }
}
