using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class AuthService: Service
    {
        public const string Path = "security/token";

        public ApiKeys ApiKeys { get; set; }

        public AuthService(ApiKeys apiKeys, HttpClient httpClient = null):base(httpClient)
        {
            ApiKeys = apiKeys;
        }


        public  async Task<Result<SuccessfulAuth>> GetAdministrationTokens(AdministrationKey administrationKey = null, CancellationToken cancellationToken = default)
        {
            administrationKey = administrationKey ?? ApiKeys.AdministrationKey;

            return await Get(administrationKey?.Key, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulAuth>> GetAddressLookupTokens(AddressLookupKey addressLookupKey = null, CancellationToken cancellationToken = default)
        {
            addressLookupKey = addressLookupKey ?? ApiKeys.AddressLookupKey;

            return await Get(addressLookupKey?.Key, cancellationToken: cancellationToken);
        }


        private async Task<Result<SuccessfulAuth>> Get(string administrationOrApiKey = null, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(Path);

            return await HttpGet<SuccessfulAuth>(requestUri, administrationOrApiKey: administrationOrApiKey, cancellationToken: cancellationToken);
        }

        

        public async Task<Result<SuccessfulAuth>> Refresh(RefreshToken refreshToken, CancellationToken cancellationToken = default)
        {
            var path = Path + "/refresh";

            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulAuth>(requestUri, token:refreshToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulAuthRevoke>> Revoke(AdministrationKey administrationKey = null, CancellationToken cancellationToken = default)
        {
            var path = Path + "/revoke";

            var requestUri = GetUri(path);

            administrationKey = administrationKey ?? ApiKeys.AdministrationKey;

            return await HttpPost<SuccessfulAuthRevoke>(requestUri, administrationOrApiKey:administrationKey?.Key, cancellationToken: cancellationToken);
        }
        

    }

        
    
}
