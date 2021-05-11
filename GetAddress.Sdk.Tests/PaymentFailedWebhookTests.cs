using Shouldly;
using System.Threading.Tasks;
using Xunit;
using System;

namespace GetAddress.Sdk.Tests
{
    public class PaymentFailedWebhookTests
    {
        [Fact]
        public async Task Given_Valid_Url_Add_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var request = new AddPaymentFailedWebhook
            {
                Url = @$"https://getaddress.io?test={Guid.NewGuid()}"
            };

            var addResult = await api.Webhooks.PaymentFailed.Add(request);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.Webhooks.PaymentFailed.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await api.Webhooks.PaymentFailed.Get();

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(0);

            var removeResult = await api.Webhooks.PaymentFailed.Remove(getResult.Success.Id);

            removeResult.IsSuccess.ShouldBeTrue();
        }
    }
}
