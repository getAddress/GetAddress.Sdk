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
}
