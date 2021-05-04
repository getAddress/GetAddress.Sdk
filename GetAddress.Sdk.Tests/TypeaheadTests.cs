using Shouldly;
using System.Collections.Generic;
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

      

        [Fact]
        public async Task Given_Top_Equals_1_Typeahead_Returns_1_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var options = new TypeaheadOptions { Top=1 };
            
            var result = await api.Typeahead("PE", options: options);

            result.IsSuccess.ShouldBeTrue();

            result.Success.Length.ShouldBe(1);
        }

        [Fact]
        public async Task Given_Filter_County_As_Northamptonshire_And_Cambs_Postcode_Typeahead_Returns_0_Results()
        {
            var api = Helpers.ApiHelper.GetApi();

            var options = new TypeaheadOptions {  };
            options.Filter.County = "Northamptonshire";

            var result = await api.Typeahead("PE10", options: options);

            result.IsSuccess.ShouldBeTrue();

            result.Success.Length.ShouldBe(0);
        }

        [Fact]
        public async Task Given_Filter_County_As_Cambs_And_Cambs_Postcode_Typeahead_Returns_multiple_Results()
        {
            var api = Helpers.ApiHelper.GetApi();

            var options = new TypeaheadOptions { };
            options.Filter.County = "Cambridgeshire";

            var result = await api.Typeahead("PE15", options: options);

            result.IsSuccess.ShouldBeTrue();

            result.Success.Length.ShouldBeGreaterThan(0);
        }
    }
}
