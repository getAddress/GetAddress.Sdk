using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class PaymentMethodsTests
    {
        [Fact]
        public async Task Get_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var listResult = await api.Account.PaymentMethods.Get();

            listResult.IsSuccess.ShouldBeTrue();
        }
    }
}
