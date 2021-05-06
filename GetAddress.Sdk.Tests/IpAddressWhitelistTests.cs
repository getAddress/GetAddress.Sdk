﻿using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Sdk.Tests
{
    public class IpAddressWhitelistTests
    {
        [Fact]
        public async Task Given_Valid_IpAddress_Add_Get_Remove_Return_Successful_Results()
        {
            var api = Helpers.ApiHelper.GetApi();

            var request = new AddIpAddress
            {
                IpAddress = "192.168.0.2"
            };

            var addResult = await api.Security.IpAddressWhitelist.Add(request);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.Security.IpAddressWhitelist.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await api.Security.IpAddressWhitelist.Get();

            listResult.IsSuccess.ShouldBeTrue();

            var removeResult = await api.Security.IpAddressWhitelist.Remove(getResult.Success.Id);

            removeResult.IsSuccess.ShouldBeTrue();
        }
    }
}