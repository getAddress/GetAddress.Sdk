using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class UsageTests
    {
        [Fact]
        public async Task Usage_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Usage();

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_Date_Usage_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var date = new DateTimeOffset(2021, 05, 04, 14, 15, 1, TimeSpan.FromHours(1));

            var result = await api.Usage(date);

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Given_From_Date_And_To_Date_Usage_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var fromDate = new DateTimeOffset(2021, 05, 01, 14, 15, 1, TimeSpan.FromHours(1));
            var toDate = new DateTimeOffset(2021, 05, 04, 14, 15, 1, TimeSpan.FromHours(1));

            var result = await api.Usage(fromDate, toDate);

            result.IsSuccess.ShouldBeTrue();
        }
    }
}
