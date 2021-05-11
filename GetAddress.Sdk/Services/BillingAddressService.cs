using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Sdk.Services
{
    public class BillingAddressService: AdministrationService
    {
        private const string path = "billing-address";

        public BillingAddressService(string administrationKey, HttpClient httpClient = null) : base(administrationKey, httpClient)
        {

        }

        public async Task<Result<BillingAddress>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<BillingAddress>();
        }

        public async Task<Result<SuccessfulBillingAddressUpdate>> Update(UpdateBillingAddress request, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var content = request.ToHttpContent();

            var response = await HttpPut(requestUri, httpContent: content, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            var result = await response.ToResult<SuccessfulBillingAddressUpdate>();

            return result;
        }

    }
}
