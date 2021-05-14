using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class UsageService : AdministrationService
    {
        private const string path = "v4/usage";

        public UsageService(string administrationKey, HttpClient httpClient = null) : base(administrationKey, httpClient)
        {

        }

        public async Task<Result<Usage>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpGet<Usage>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<Usage>> Get(DateTimeOffset date, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var year = date.UtcDateTime.Year;
            var month = date.UtcDateTime.Month;
            var day = date.UtcDateTime.Day;

            var usagePath = $"{path}/{day}/{month}/{year}";

            var requestUri = GetUri(usagePath);

            return await HttpGet<Usage>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

        }

        public async Task<Result<Usage[]>> Get(DateTimeOffset from, DateTimeOffset to, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var fromYear = from.UtcDateTime.Year;
            var fromMonth = from.UtcDateTime.Month;
            var fromDay = from.UtcDateTime.Day;

            var toYear = to.UtcDateTime.Year;
            var toMonth = to.UtcDateTime.Month;
            var today = to.UtcDateTime.Day;

            var usagePath = $"{path}/from/{fromDay}/{fromMonth}/{fromYear}/to/{today}/{toMonth}/{toYear}";

            var requestUri = GetUri(usagePath);

            return await HttpGet<Usage[]>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }
    }
}
