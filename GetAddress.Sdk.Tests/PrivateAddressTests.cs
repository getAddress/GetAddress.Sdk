using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class PrivateAddressTests
    {
        [Fact]
        public async Task Can_Successfully_Create_Private_Address()
        {
            var api = Helpers.ApiHelper.GetApi();

            var addPrivateAddress = new AddPrivateAddress
            {
                  Postcode = "NN1 3ER",
                  Line1 = "Flat 9",
            };

            var addResult = await api.PrivateAddress.Add(addPrivateAddress);

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.PrivateAddress.Get(addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await api.PrivateAddress.List();

            listResult.IsSuccess.ShouldBeTrue();

            listResult.Success.Length.ShouldBeGreaterThan(0);

            var removeResult = await api.PrivateAddress.Remove(addResult.Success.Id);

            removeResult.IsSuccess.ShouldBeTrue();

        }
    }

}
