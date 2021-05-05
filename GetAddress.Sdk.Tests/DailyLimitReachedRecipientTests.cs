﻿using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Sdk.Tests
{
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

            var addResult = await api.EmailNotifications.DailyLimitedReached.Add(request);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.EmailNotifications.DailyLimitedReached.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await api.EmailNotifications.DailyLimitedReached.Get();

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(1);

            var removeResult = await api.EmailNotifications.DailyLimitedReached.Remove(getResult.Success.Id);

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

            var addResult = await apiNoKeys.EmailNotifications.DailyLimitedReached.Add(request, accessToken: tokenResult.Success.Tokens.Access);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await apiNoKeys.EmailNotifications.DailyLimitedReached.Get(addResult.Success.Id, accessToken: tokenResult.Success.Tokens.Access);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await apiNoKeys.EmailNotifications.DailyLimitedReached.Get(accessToken: tokenResult.Success.Tokens.Access);

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(1);

            var removeResult = await apiNoKeys.EmailNotifications.DailyLimitedReached.Remove(getResult.Success.Id, accessToken: tokenResult.Success.Tokens.Access);

            removeResult.IsSuccess.ShouldBeTrue();
        }
    }
}