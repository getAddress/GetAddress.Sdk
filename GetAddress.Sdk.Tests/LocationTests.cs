using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class LocationTests
    {

        [Fact]
        public async Task Given_Postcode_Location_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Location("AB159HL");

            result.IsSuccess.ShouldBeTrue();
        }



        [Fact]
        public async Task Given_Known_Town_Location_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Location("Kettering");

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Token_Location_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var authResult = await api.Security.Authentication.GetAddressLookupTokens();

            authResult.IsSuccess.ShouldBeTrue();

            var auth = authResult.Success;

            var apiNoKeys = Helpers.ApiHelper.GetApiNoKeys();

            var result = await apiNoKeys.Location("Kettering", accessToken: auth.Tokens.Access);

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Top_As_5_Location_Returns_The_Top_2()
        {
            var api = Helpers.ApiHelper.GetApi();

            var options = new LocationOptions
            {
                Top = 2
            };

            var result = await api.Location("PE15", options: options);

            result.IsSuccess.ShouldBeTrue();

            result.Success.Suggestions.Length.ShouldBe(2);
        }




        [Fact]
        public async Task Given_Northamptonshire_County_Filter_Location_Returns_Only_Suggestions_From_Northampton()
        {
            var api = Helpers.ApiHelper.GetApi();

            var options = new LocationOptions
            {

            };

            options.Filter.County = "Northamptonshire";

            var result = await api.Location("PE15 0SR", options: options);

            result.IsSuccess.ShouldBeTrue();

            result.Success.Suggestions.Length.ShouldBe(0);

            var result2 = await api.Location("NN1 3ER", options: options);

            result2.IsSuccess.ShouldBeTrue();

            result2.Success.Suggestions.Length.ShouldBeGreaterThan(0);
        }


        [Fact]
        public async Task Given_Yorkshire_Location_Location_Returns_Suggestions_From_Yorkshire()
        {
            var api = Helpers.ApiHelper.GetApi();

            var options = new LocationOptions
            {

            };

            options.Location.Latitude = 53.42416763305664;
            options.Location.Longitude = -1.45220148563385;

            var result = await api.Location("Sheffield", options: options);

            result.IsSuccess.ShouldBeTrue();

            result.Success.Suggestions.Length.ShouldBeGreaterThan(0);

            result.Success.Suggestions.First().Location.Contains("Yorkshire").ShouldBeTrue();

        }

    
    }
}
