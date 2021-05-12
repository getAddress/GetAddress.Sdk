using Shouldly;
using System.Threading.Tasks;
using Xunit;
using System;

namespace GetAddress.Tests
{
    public class ExpiredWebhookTests
    {
        [Fact]
        public async Task Given_Valid_Url_Add_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var request = new AddExpiredWebhook
            {
                Url = @$"https://getaddress.io?test={Guid.NewGuid()}"
            };

            var addResult = await api.Webhooks.Expired.Add(request);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.Webhooks.Expired.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await api.Webhooks.Expired.Get();

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(0);

            var removeResult = await api.Webhooks.Expired.Remove(getResult.Success.Id);

            removeResult.IsSuccess.ShouldBeTrue();
        }
    }
}
