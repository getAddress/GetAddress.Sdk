using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class DomainWhitelistTests
    {
        [Fact]
        public async Task Given_Valid_Domain_Add_Get_Remove_Return_Successful_Results()
        {
            var api = Helpers.ApiHelper.GetApiWithDomainWhitelistKeys();

            var listResult = await api.Security.DomainWhitelist.Get();

            listResult.IsSuccess.ShouldBeTrue();

            foreach (var ip in listResult.Success)
            {
                var remove = await api.Security.DomainWhitelist.Remove(ip.Id);

                remove.IsSuccess.ShouldBeTrue();
            }

            var request = new AddDomainName
            {
                 DomainName = "https://testing.getaddress.io"
            };

            var addResult = await api.Security.DomainWhitelist.Add(request);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.Security.DomainWhitelist.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

           

            listResult.IsSuccess.ShouldBeTrue();

            var removeResult = await api.Security.DomainWhitelist.Remove(getResult.Success.Id);

            removeResult.IsSuccess.ShouldBeTrue();
        }
    }


    public class AdminPermissionsTests
    {
        [Fact]
        public async Task Add_Get_Remove_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var listResult = await api.Security.AdminPermissions.Get();

            listResult.IsSuccess.ShouldBeTrue();

            foreach (var permisions in listResult.Success)
            {
                var remove = await api.Security.AdminPermissions.Remove(permisions.Name);

                remove.IsSuccess.ShouldBeTrue();
            }

            var request = new AddAdminPermissions
            {
                Name = "test",
                Expires = DateTime.UtcNow.AddDays(1),
                Permissions = new AdminPermissions { 
                 CanUnsubscribe = true,
                 CanUpgrade = true,
                 CreateSubscription = true,
                 ViewBillingAddress = true,
                 ViewInvoices = true,
                 ViewMonitor = true,
                 ViewNotifications = true,
                 ViewPaymentMethods = true,
                 ViewSecurity = true,
                 Addresses = true
                }
            };
            
            var addResult = await api.Security.AdminPermissions.Add(request);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.Security.AdminPermissions.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var removeResult = await api.Security.AdminPermissions.Remove(getResult.Success.Name);

            removeResult.IsSuccess.ShouldBeTrue();
        }
    }
}
