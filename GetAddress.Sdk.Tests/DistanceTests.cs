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
    }
}
