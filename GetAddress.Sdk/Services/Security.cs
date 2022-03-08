using System.Net.Http;

namespace GetAddress.Services
{
    public class Security
    {
        public ApiKeyService ApiKey
        {
            get;
        }

        public DomainTokenService DomainTokenService
        {
            get;
        }

        public AuthService Authentication
        {
            get;
        }

        public DomainWhitelistService DomainWhitelist
        {
            get;
        }

        public IpAddressWhitelistService IpAddressWhitelist
        {
            get;
        }

        public Security(ApiKeys apiKeys, HttpClient httpClient = null)
        {
            Authentication = new AuthService(apiKeys, httpClient: httpClient);
            ApiKey = new ApiKeyService(apiKeys.AdministrationKey, httpClient: httpClient);
            DomainWhitelist = new DomainWhitelistService(apiKeys.AdministrationKey, httpClient: httpClient);
            IpAddressWhitelist = new IpAddressWhitelistService(apiKeys.AdministrationKey, httpClient: httpClient);
            DomainTokenService = new DomainTokenService(apiKeys.AdministrationKey, httpClient: httpClient);
        }
    }

        
    
}
