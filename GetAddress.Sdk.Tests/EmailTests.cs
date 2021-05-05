using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Sdk.Tests
{
    public class EmailTests
    {
        [Fact]
        public async Task Get_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Email.Get();

            result.IsSuccess.ShouldBeTrue();

            var newEmailAddress = $"{System.Guid.NewGuid()}@getaddress.io";

            var updateResult = await api.Email.Update(new UpdateEmailRequest { NewEmailAddress = newEmailAddress });

            updateResult.IsSuccess.ShouldBeTrue();

            var updateResult2 = await api.Email.Update(new UpdateEmailRequest { NewEmailAddress = result.Success.EmailAddress });

            updateResult2.IsSuccess.ShouldBeTrue();
        }
    }
}
