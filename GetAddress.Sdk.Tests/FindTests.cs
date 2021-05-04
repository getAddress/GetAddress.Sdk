using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Sdk.Tests
{
    public class EmailTests
    {
        [Fact]
        public async Task Get_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Email.Get();

            result.IsSuccess.ShouldBeTrue();

            var newEmailAddress = $"{System.Guid.NewGuid()}@getaddress.io";

            var updateResult = await api.Email.Update(new UpdateEmailRequest { NewEmailAddress = newEmailAddress });

            updateResult.IsSuccess.ShouldBeTrue();

            var updateResult2 = await api.Email.Update(new UpdateEmailRequest { NewEmailAddress = result.Success.EmailAddress });

            updateResult2.IsSuccess.ShouldBeTrue();
        }
    }
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
        public async Task Given_Access_Token_Find_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var authResult = await api.Security.Token.GetTokens();

            authResult.IsSuccess.ShouldBeTrue();

            var auth = authResult.Success;

            var apiNoKeys = Helpers.ApiHelper.GetApiNoKeys();

            var result = await apiNoKeys.Find("TR19 7AA", accessToken: auth.Tokens.Access);

            result.IsSuccess.ShouldBeTrue();

            var result2 = await api.Find("TR19 7AA");

            result2.IsSuccess.ShouldBeTrue();

            var result3 = await apiNoKeys.Find("TR19 7AA", accessToken: auth.Tokens.Access);

            result3.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Known_Postcode_And_HouseName_Find_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Find("TR19 7AA", new FindOptions { HouseNameOrNumber = "Lands End" });

            result.IsSuccess.ShouldBeTrue();

            result.Success.Addresses.Length.ShouldBeGreaterThan(0);
        }
    }
}
