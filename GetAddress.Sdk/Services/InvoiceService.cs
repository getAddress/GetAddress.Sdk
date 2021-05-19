using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class InvoiceService : AdministrationService
    {
        private const string path = "invoices";
        public InvoiceService(AdministrationKey administrationKey, HttpClient httpClient = null) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<Invoice[]>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpGet<Invoice[]>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<Invoice>> Get(string number, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri($"{path}/{number}");

            return await HttpGet<Invoice>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<Invoice[]>> Get(DateTimeOffset from, DateTimeOffset to, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var fromYear = from.UtcDateTime.Year;
            var fromMonth = from.UtcDateTime.Month;
            var fromDay = from.UtcDateTime.Day;

            var toYear = to.UtcDateTime.Year;
            var toMonth = to.UtcDateTime.Month;
            var today = to.UtcDateTime.Day;

            var invoicePath = $"{path}/from/{fromDay}/{fromMonth}/{fromYear}/to/{today}/{toMonth}/{toYear}";

            var requestUri = GetUri(invoicePath);

            return await HttpGet<Invoice[]>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }
    }
}
