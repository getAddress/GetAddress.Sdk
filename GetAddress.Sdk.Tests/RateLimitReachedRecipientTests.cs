using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class RateLimitReachedRecipientTests
    {
        [Fact]
        public async Task Given_Valid_EmailAddress_Add_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var request = new AddRateLimitReachedEmailRecipient
            {
                EmailAddress = $"{System.Guid.NewGuid()}@getaddress.io"
            };

            var addResult = await api.EmailNotifications.RateLimitReached.Add(request);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.EmailNotifications.RateLimitReached.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await api.EmailNotifications.RateLimitReached.Get();

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(1);

            var removeResult = await api.EmailNotifications.RateLimitReached.Remove(getResult.Success.Id);

            removeResult.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Valid_Token_Add_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var request = new AddRateLimitReachedEmailRecipient
            {
                EmailAddress = $"{System.Guid.NewGuid()}@getaddress.io"
            };

            var tokenResult = await api.Security.Authentication.GetAdministrationTokens();

            tokenResult.IsSuccess.ShouldBeTrue();

            var apiNoKeys = Helpers.ApiHelper.GetApiNoKeys();

            var addResult = await apiNoKeys.EmailNotifications.RateLimitReached.Add(request, accessToken: tokenResult.Success.Tokens.Access);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await apiNoKeys.EmailNotifications.RateLimitReached.Get(addResult.Success.Id, accessToken: tokenResult.Success.Tokens.Access);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await apiNoKeys.EmailNotifications.RateLimitReached.Get(accessToken: tokenResult.Success.Tokens.Access);

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(1);

            var removeResult = await apiNoKeys.EmailNotifications.RateLimitReached.Remove(getResult.Success.Id, accessToken: tokenResult.Success.Tokens.Access);

            removeResult.IsSuccess.ShouldBeTrue();
        }
    }
}
