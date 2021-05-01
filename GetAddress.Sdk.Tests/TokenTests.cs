using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Sdk.Tests
{
    public class TokenTests
    {
        [Fact]
        public async Task Given_AdministationKey_GetAdministrationTokens_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Security.Token.GetAdministrationTokens();

            result.IsSuccess.ShouldBeTrue();
        }


        [Fact]
        public async Task Given_Valid_Refresh_Token_Refresh_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var tokensResult = await api.Security.Token.GetAdministrationTokens();

            tokensResult.IsSuccess.ShouldBeTrue();

            var success = tokensResult.Success;

            var result = await api.Security.Token.Refresh(success.Tokens.Refresh);

            result.IsSuccess.ShouldBeTrue();
        }
    }
}
