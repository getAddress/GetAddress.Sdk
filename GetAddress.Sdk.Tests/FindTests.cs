using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Sdk.Tests
{
    public class TypeaheadTests
    {
        [Fact]
        public async Task Given_Term_Typeahead_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Typeahead("PR");

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Access_Token_Typeahead_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var authResult = await api.Security.Token.GetTokens();

            authResult.IsSuccess.ShouldBeTrue();

            var auth = authResult.Success;

            var apiNoKeys = Helpers.ApiHelper.GetApiNoKeys();

            var result = await apiNoKeys.Typeahead("PE", accessToken: auth.Tokens.Access);

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_No_Token_Or_Keys_Typeahead_Returns_Failed_Result()
        {
            var apiNoKeys = Helpers.ApiHelper.GetApiNoKeys();

            var result = await apiNoKeys.Typeahead("PE");

            result.IsSuccess.ShouldBeFalse();
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
        }
    }
}
