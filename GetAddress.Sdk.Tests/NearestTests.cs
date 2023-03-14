using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class NearestTests
    {

        [Fact]
        public async Task Given_A_Valid_GeoLocation_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Nearest(53.0833957, -2.8692477);

            result.IsSuccess.ShouldBeTrue();
        }
    }

    public class NearestLocationTests
    {

        [Fact]
        public async Task Given_A_Valid_GeoLocation_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.NearestLocation(53.0833957, -2.8692477);

            result.IsSuccess.ShouldBeTrue();
        }
    }
}
