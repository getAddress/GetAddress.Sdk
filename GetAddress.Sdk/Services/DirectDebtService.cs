using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class DirectDebtService : AdministrationService
    {
        private const string path = "direct-debt";
        public DirectDebtService(AdministrationKey administrationKey, HttpClient httpClient = null) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<BankDetails>> BankDetails(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            return await HttpGet<BankDetails>(GetUri(path + "/bank-details"), administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }
    }
}
