using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class DiectDebtTests
    {
        [Fact]
        public async Task BankDetails_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetDirectDebtApi();

            var result = await api.DirectDebt.BankDetails();

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Status_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetDirectDebtApi();

            var result = await api.DirectDebt.Status();

            result.IsSuccess.ShouldBeTrue();
        }

    }
}
