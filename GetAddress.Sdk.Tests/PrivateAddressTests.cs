using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{

    public class PrivateAddressTests
    {
        [Fact]
        public async Task Get_Returns_Successful_Result()
        {
            var postcode = "NN13ER";

            var api = Helpers.ApiHelper.GetApi();

            var result = await api.PrivateAddress.Get(postcode);

            result.IsSuccess.ShouldBeTrue();

            foreach(var address in result.Success)
            {
                var removeResult = await api.PrivateAddress.Remove(postcode, address.Id);
                removeResult.IsSuccess.ShouldBeTrue();
            }

            var addResult = await api.PrivateAddress.Add(postcode, new AddPrivateAddress { 
             County=Guid.NewGuid().ToString(),
             Line1 = Guid.NewGuid().ToString(),
             Line2 = Guid.NewGuid().ToString(),
             Line3 = Guid.NewGuid().ToString(),
             Line4 = Guid.NewGuid().ToString(),
             Locality = Guid.NewGuid().ToString(),
             TownOrCity = Guid.NewGuid().ToString()
            });

            addResult.IsSuccess.ShouldBeTrue();

            var getResult = await api.PrivateAddress.Get(postcode, addResult.Success.Id);

            getResult.IsSuccess.ShouldBeTrue();

            var listResult = await api.PrivateAddress.Get(postcode);

            listResult.IsSuccess.ShouldBeTrue();

            var removeResult2 = await api.PrivateAddress.Remove(postcode, getResult.Success.Id);

            removeResult2.IsSuccess.ShouldBeTrue();

        }

    }
}
