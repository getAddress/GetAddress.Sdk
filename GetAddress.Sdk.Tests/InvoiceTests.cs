using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace GetAddress.Tests
{
    public class InvoiceTests
    {
        [Fact]
        public async Task Get_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var result = await api.Invoice.Get();

            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task Get_Multiple_Returns_Successful_Result()
        {
            var api = Helpers.ApiHelper.GetApi();

            var invoices = await api.Invoice.Get();

            invoices.IsSuccess.ShouldBeTrue();

            foreach(var invoice in invoices.Success)
            {
                var singleInvoice = await api.Invoice.Get(invoice.Number);
                singleInvoice.IsSuccess.ShouldBeTrue();
            }
        }
    }
}
