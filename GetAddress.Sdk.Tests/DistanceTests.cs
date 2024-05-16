using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class DistanceTests
    {
        [Fact]
        public async Task Given_Known_Postcodes_Distance_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Distance("TR19 7AA", "KW1 4YT");

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Known_Coordinates_Distance_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Distance(52.245927, -0.891623, 52.493816045614025, 0.054838301754385976);

            result.IsSuccess.ShouldBeTrue();
        }
    }
}
