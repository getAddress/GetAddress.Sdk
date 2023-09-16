using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class DomainTokenTests
    {
        [Fact]
        public async Task Can_Successfully_Create_Domain_Token()
        {
            var api = Helpers.ApiHelper.GetApi();

            var addDomainToken = new AddDomainToken {
                Url = "https://getaddress.io",
                Limit = 10,
                LimitMinutes = 5
            };

            var addResult = await api.Security.DomainToken.Add(addDomainToken);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.Security.DomainToken.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await api.Security.DomainToken.List();

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(0);

            var removeResult = await api.Security.DomainToken.Remove(addResult.Success.Id);

            removeResult.IsSuccess.ShouldBeTrue();

        }
    }

}
