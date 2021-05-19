using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class InvoiceEmailRecipientService : AdministrationService
    {
        private const string path = "cc/invoices";

        public InvoiceEmailRecipientService(AdministrationKey administrationKey, HttpClient httpClient) :base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<SuccessfulInvoiceEmailRecipient>> Get(string id,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpGet<SuccessfulInvoiceEmailRecipient>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulInvoiceEmailRecipient[]>> Get(
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {

            var requestUri = GetUri(path);

            return  await HttpGet<SuccessfulInvoiceEmailRecipient[]>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulInvoiceEmailRecipientAdd>> Add(AddInvoiceEmailRecipient request,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulInvoiceEmailRecipientAdd>(requestUri, data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulInvoiceEmailRecipientRemove>> Remove(string id, 
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{id}";

            var requestUri = GetUri(removePath);

            return await HttpDelete<SuccessfulInvoiceEmailRecipientRemove>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

    }
}
