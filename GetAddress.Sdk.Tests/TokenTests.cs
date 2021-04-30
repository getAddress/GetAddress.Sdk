using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Sdk.Tests
{
    public class TokenTests
    {
        [Fact]
        public async Task Given_AdministationKey_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Security.Token.Get();

            result.IsSuccess.ShouldBeTrue();
        }
    }
}
