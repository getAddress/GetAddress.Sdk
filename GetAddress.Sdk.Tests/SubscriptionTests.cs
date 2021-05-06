using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Sdk.Tests
{

    public class SubscriptionTests
    {
        [Fact]
        public async Task Get_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Subscription.Get();

            result.IsSuccess.ShouldBeTrue();
        }
    }
}
