using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Sdk.Tests
{
    public class AutocompleteTests
    {
        [Fact]
        public async Task Given_Known_Term_Autocomplete_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Autocomplete("Codeberry Ltd");

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Token_Autocomplete_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var authResult = await api.Security.Token.GetTokens();

            authResult.IsSuccess.ShouldBeTrue();

            var auth = authResult.Success;

            var apiNoKeys = Helpers.ApiHelper.GetApiNoKeys();

            var result = await apiNoKeys.Autocomplete("Codeberry Ltd", accessToken:auth.Tokens.Access);

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Top_As_5_Autocomplete_Returns_The_Top_5()
        {
            var api = Helpers.ApiHelper.GetApi();
           
            var options = new AutocompleteOptions { 
              Top = 5
            };

            var result = await api.Autocomplete("PE15", options:options);

            result.IsSuccess.ShouldBeTrue();

            result.Success.Suggestions.Length.ShouldBe(5); 
        }

        [Fact]
        public async Task Given_All_Autocomplete_Returns_All_Suggestions_For_Postcode()
        {
            var api = Helpers.ApiHelper.GetApi();

            var options = new AutocompleteOptions
            {
                All=true
            };

            var result = await api.Autocomplete("PE15 0SR", options: options);

            result.IsSuccess.ShouldBeTrue();

            result.Success.Suggestions.Length.ShouldBeGreaterThan(6);
        }

        [Fact]
        public async Task Given_All_As_False_Autocomplete_Returns_6_Suggestions_For_Postcode()
        {
            var api = Helpers.ApiHelper.GetApi();

            var options = new AutocompleteOptions
            {
                All = false
            };

            var result = await api.Autocomplete("PE15 0SR", options: options);

            result.IsSuccess.ShouldBeTrue();

            result.Success.Suggestions.Length.ShouldBeLessThanOrEqualTo(6);
        }

        [Fact]
        public async Task Given_Northamptonshire_County_Filter_Autocomplete_Returns_Only_Suggestions_From_Northampton()
        {
            var api = Helpers.ApiHelper.GetApi();

            var options = new AutocompleteOptions
            {
                
            };

            options.Filter.County = "Northamptonshire";

            var result = await api.Autocomplete("PE15 0SR", options: options);

            result.IsSuccess.ShouldBeTrue();

            result.Success.Suggestions.Length.ShouldBe(0);

            var result2 = await api.Autocomplete("NN1 3ER", options: options);

            result2.IsSuccess.ShouldBeTrue();

            result2.Success.Suggestions.Length.ShouldBeGreaterThan(0);
        }


        [Fact]
        public async Task Given_Yorkshire_Location_Autocomplete_Returns_Suggestions_From_Yorkshire()
        {
            var api = Helpers.ApiHelper.GetApi();

            var options = new AutocompleteOptions
            {

            };

            options.Location.Latitude = 53.42416763305664;
            options.Location.Longitude = -1.45220148563385;

            var result = await api.Autocomplete("Homestead Road", options: options);

            result.IsSuccess.ShouldBeTrue();

            result.Success.Suggestions.Length.ShouldBeGreaterThan(0);

            result.Success.Suggestions.First().Address.Contains("Yorkshire").ShouldBeTrue();

        }

        [Fact]
        public async Task Given_No_Location_Autocomplete_Returns_Suggestions_From_London()
        {
            var api = Helpers.ApiHelper.GetApi();

            var options = new AutocompleteOptions
            {

            };

            var result = await api.Autocomplete("Homestead Road", options: options);

            result.IsSuccess.ShouldBeTrue();

            result.Success.Suggestions.Length.ShouldBeGreaterThan(0);

            result.Success.Suggestions.First().Address.Contains("London").ShouldBeTrue();

        }

    }
}
