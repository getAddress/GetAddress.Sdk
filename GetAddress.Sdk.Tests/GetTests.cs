using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class GetTests
    {
        [Fact]
        public async Task Given_Known_Term_Get_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Autocomplete("Codeberry Ltd");

            result.IsSuccess.ShouldBeTrue();

            var getResult = await api.Get(result.Success.Suggestions.First());

            getResult.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Known_Term_Get_With_Id_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Autocomplete("Codeberry Ltd");

            result.IsSuccess.ShouldBeTrue();

            var getResult = await api.Get(result.Success.Suggestions.First().Id);

            getResult.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Token_Get_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var authResult = await api.Security.Authentication.GetAddressLookupTokens();

            authResult.IsSuccess.ShouldBeTrue();

            var auth = authResult.Success;

            var apiNoKeys = Helpers.ApiHelper.GetApiNoKeys();

            var result = await apiNoKeys.Autocomplete("Codeberry Ltd", accessToken:auth.Tokens.Access);

            result.IsSuccess.ShouldBeTrue();

            var getResult = await apiNoKeys.Get(result.Success.Suggestions.First(), accessToken: auth.Tokens.Access);

            getResult.IsSuccess.ShouldBeTrue();
        }
    }
}
