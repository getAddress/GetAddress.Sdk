using Shouldly;
using System.Threading.Tasks;
using Xunit;
using System;

namespace GetAddress.Tests
{

    public class DailyLimitReachedWebhookTests
    {
        [Fact]
        public async Task Given_Valid_Url_Add_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var listResult = await api.Webhooks.DailyLimitReached.Get();

            listResult.IsSuccess.ShouldBeTrue();

            foreach(var webhook in listResult.Success)
            {
                var remove = await api.Webhooks.DailyLimitReached.Remove(webhook.Id);
                
                remove.IsSuccess.ShouldBeTrue();
            }

            var request = new AddDailyLimitReachedWebhook
            {
                Url = @$"https://getaddress.io?test={Guid.NewGuid()}"
            };

            request.Options = new AddWebhookOptions { Auth = "auth_test", P256dh = "p256dh_test" };

            var addResult = await api.Webhooks.DailyLimitReached.Add(request);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.Webhooks.DailyLimitReached.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var removeResult = await api.Webhooks.DailyLimitReached.Remove(getResult.Success.Id);

            removeResult.IsSuccess.ShouldBeTrue();
        }
    }
}
