using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{

    public class SubscriptionTests
    {
        [Fact]
        public async Task Get_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Subscription.Get();

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Update_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Subscription.Update(new UpdateSubscription
            {
                Name = Guid.NewGuid().ToString()
            }) ;

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Update_AttachInvoices_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Subscription.Update(new UpdateSubscription
            {
                AttachInvoices = true
            });

            result.IsSuccess.ShouldBeTrue();
        }
    }
}
