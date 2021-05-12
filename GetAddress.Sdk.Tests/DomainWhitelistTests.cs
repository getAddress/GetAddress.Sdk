using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class DomainWhitelistTests
    {
        [Fact]
        public async Task Given_Valid_Domain_Add_Get_Remove_Return_Successful_Results()
        {
            var api = Helpers.ApiHelper.GetApi();

            var request = new AddDomainName
            {
                 DomainName = "https://testing.getaddress.io"
            };

            var addResult = await api.Security.DomainWhitelist.Add(request);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.Security.DomainWhitelist.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await api.Security.DomainWhitelist.Get();

            listResult.IsSuccess.ShouldBeTrue();

            var removeResult = await api.Security.DomainWhitelist.Remove(getResult.Success.Id);

            removeResult.IsSuccess.ShouldBeTrue();
        }
    }
}
