﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class Security
    {
        public ApiKeyService ApiKey
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

        public Security(string apiKey, string administrationKey, HttpClient httpClient = null)
        {
            Authentication = new AuthService(apiKey, administrationKey, httpClient: httpClient);
            ApiKey = new ApiKeyService(administrationKey, httpClient: httpClient);
            DomainWhitelist = new DomainWhitelistService(administrationKey, httpClient: httpClient);
            IpAddressWhitelist = new IpAddressWhitelistService(administrationKey, httpClient: httpClient);
        }
    }

    public class AuthService: Service
    {
        public const string Path = "security/token";

        public AuthService(HttpClient httpClient = null) : base(httpClient)
        {

        }

        public AuthService(string apiKey, string administrationKey, HttpClient httpClient = null):this(httpClient)
        {
            ApiKey = apiKey;
            AdministrationKey = administrationKey;
        }

        public string ApiKey { get; set; }

        public string AdministrationKey { get; set; }

        public  async Task<Result<SuccessfulAuth>> GetAdministrationTokens(string administrationKey = null, CancellationToken cancellationToken = default)
        {
            administrationKey = administrationKey ?? AdministrationKey;

            return await Get(administrationKey, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulAuth>> GetTokens(string apiKey = null, CancellationToken cancellationToken = default)
        {
            apiKey = apiKey ?? ApiKey;

            return await Get(apiKey, cancellationToken: cancellationToken);
        }


        private async Task<Result<SuccessfulAuth>> Get(string administrationOrApiKey = null, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(Path);

            var response = await HttpGet(requestUri, administrationOrApiKey: administrationOrApiKey, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulAuth>();
        }

        

        public async Task<Result<SuccessfulAuth>> Refresh(RefreshToken refreshToken, CancellationToken cancellationToken = default)
        {
            var path = Path + "/refresh";

            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulAuth>(requestUri, token:refreshToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulAuthRevoke>> Revoke(string administrationKey = null, CancellationToken cancellationToken = default)
        {
            var path = Path + "/revoke";

            var requestUri = GetUri(path);

            administrationKey = administrationKey ?? AdministrationKey;

            return await HttpPost<SuccessfulAuthRevoke>(requestUri, administrationOrApiKey:administrationKey, cancellationToken: cancellationToken);
        }
        

    }

        
    
}
