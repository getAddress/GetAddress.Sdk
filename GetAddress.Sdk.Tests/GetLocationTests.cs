using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class GetLocationTests
    {
        [Fact]
        public async Task Given_Known_Term_Get_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Location("Kettering");

            result.IsSuccess.ShouldBeTrue();

            var getResult = await api.GetLocation(result.Success.Suggestions.First());

            getResult.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Known_Term_GetLocation_With_Id_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Location("Kettering");

            result.IsSuccess.ShouldBeTrue();

            var getResult = await api.GetLocation(result.Success.Suggestions.First().Id);

            getResult.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Token_GetLocation_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var authResult = await api.Security.Authentication.GetAddressLookupTokens();

            authResult.IsSuccess.ShouldBeTrue();

            var auth = authResult.Success;

            var apiNoKeys = Helpers.ApiHelper.GetApiNoKeys();

            var result = await apiNoKeys.Location("Kettering", accessToken:auth.Tokens.Access);

            result.IsSuccess.ShouldBeTrue();

            var getResult = await apiNoKeys.GetLocation(result.Success.Suggestions.First(), accessToken: auth.Tokens.Access);

            getResult.IsSuccess.ShouldBeTrue();
        }
    }
}
