using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class EmailTests
    {
        [Fact(Skip = "Async updates")]
        public async Task Get_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Account.EmailAddress.Get();

            result.IsSuccess.ShouldBeTrue();

            var newEmailAddress = $"{System.Guid.NewGuid()}@getaddress.io";

            var updateResult = await api.Account.EmailAddress.Update(new UpdateEmail{ NewEmailAddress = newEmailAddress });

            updateResult.IsSuccess.ShouldBeTrue();

            var updateResult2 = await api.Account.EmailAddress.Update(new UpdateEmail { NewEmailAddress = result.Success.EmailAddress });

            updateResult2.IsSuccess.ShouldBeTrue();
        }
    }
}
