using Shouldly;
using System.Threading.Tasks;
using Xunit;
using System;

namespace GetAddress.Sdk.Tests
{
    public class DailyLimitReachedWebhookTests
    {
        [Fact]
        public async Task Given_Valid_Url_Add_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var request = new AddDailyLimitReachedWebhook
            {
                Url = @$"https://getaddress.io?test={Guid.NewGuid()}"
            };

            var addResult = await api.Webhooks.DailyLimitReached.Add(request);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.Webhooks.DailyLimitReached.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await api.Webhooks.DailyLimitReached.Get();

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(1);

            var removeResult = await api.Webhooks.DailyLimitReached.Remove(getResult.Success.Id);

            removeResult.IsSuccess.ShouldBeTrue();
        }
    }


    public class DailyLimitReachedRecipientTests
    {
        [Fact]
        public async Task Given_Valid_EmailAddress_Add_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var request = new AddDailyLimitReachedEmailRecipient
            {
                EmailAddress = $"{System.Guid.NewGuid()}@getaddress.io"
            };

            var addResult = await api.EmailNotifications.DailyLimitReached.Add(request);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.EmailNotifications.DailyLimitReached.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await api.EmailNotifications.DailyLimitReached.Get();

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(1);

            var removeResult = await api.EmailNotifications.DailyLimitReached.Remove(getResult.Success.Id);

            removeResult.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Valid_Token_Add_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var request = new AddDailyLimitReachedEmailRecipient
            {
                EmailAddress = $"{System.Guid.NewGuid()}@getaddress.io"
            };

            var tokenResult = await api.Security.Token.GetAdministrationTokens();

            tokenResult.IsSuccess.ShouldBeTrue();

            var apiNoKeys = Helpers.ApiHelper.GetApiNoKeys();

            var addResult = await apiNoKeys.EmailNotifications.DailyLimitReached.Add(request, accessToken: tokenResult.Success.Tokens.Access);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await apiNoKeys.EmailNotifications.DailyLimitReached.Get(addResult.Success.Id, accessToken: tokenResult.Success.Tokens.Access);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await apiNoKeys.EmailNotifications.DailyLimitReached.Get(accessToken: tokenResult.Success.Tokens.Access);

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(1);

            var removeResult = await apiNoKeys.EmailNotifications.DailyLimitReached.Remove(getResult.Success.Id, accessToken: tokenResult.Success.Tokens.Access);

            removeResult.IsSuccess.ShouldBeTrue();
        }
    }
}
