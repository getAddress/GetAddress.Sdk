using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Sdk.Tests
{
    public class ExpiredEmailRecipientTests
    {
        [Fact]
        public async Task Given_Valid_EmailAddress_Add_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var request = new AddExpiredEmailRecipientRequest
            {
                EmailAddress = $"{System.Guid.NewGuid()}@getaddress.io"
            };

            var addResult = await api.EmailNotifications.Expired.Add(request);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.EmailNotifications.Expired.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await api.EmailNotifications.Expired.Get();

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(1);

            var removeResult = await api.EmailNotifications.Expired.Remove(getResult.Success.Id);

            removeResult.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Valid_Token_Add_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var request = new AddExpiredEmailRecipientRequest
            {
                EmailAddress = $"{System.Guid.NewGuid()}@getaddress.io"
            };

            var tokenResult = await api.Security.Token.GetAdministrationTokens();

            tokenResult.IsSuccess.ShouldBeTrue();

            var apiNoKeys = Helpers.ApiHelper.GetApiNoKeys();

            var addResult = await apiNoKeys.EmailNotifications.Expired.Add(request, accessToken: tokenResult.Success.Tokens.Access);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await apiNoKeys.EmailNotifications.Expired.Get(addResult.Success.Id, accessToken: tokenResult.Success.Tokens.Access);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await apiNoKeys.EmailNotifications.Expired.Get(accessToken: tokenResult.Success.Tokens.Access);

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(1);

            var removeResult = await apiNoKeys.EmailNotifications.Expired.Remove(getResult.Success.Id, accessToken: tokenResult.Success.Tokens.Access);

            removeResult.IsSuccess.ShouldBeTrue();
        }
    }
}
