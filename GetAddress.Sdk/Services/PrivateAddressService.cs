using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class PrivateAddressService : AdministrationService
    {
        private const string path = "private-address";
        public PrivateAddressService(AdministrationKey administrationKey, HttpClient httpClient = null) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<PrivateAddress[]>> Get(string postcode, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetPrivateAddressUri($"{path}/{postcode}");

            return await HttpGet<PrivateAddress[]>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<PrivateAddress>> Get(string postcode, string id, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {

            var requestUri = GetPrivateAddressUri($"{path}/{postcode}/{id}");

            return await HttpGet<PrivateAddress>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        private Uri GetPrivateAddressUri(string path)
        {
            var nameValues = new NameValueCollection();

            nameValues.Add("api-version", "2021-05-26");

            return GetUri(path, nameValues);
        }

        public async Task<Result<SuccessfulPrivateAddressAdd>> Add(string postcode, AddPrivateAddress request, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri($"{path}/{postcode}");

            return await HttpPost<SuccessfulPrivateAddressAdd>(requestUri, data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

        }

        public async Task<Result<SuccessfulPrivateAddressRemove>> Remove(string postcode,string id,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri($"{path}/{postcode}/{id}");

            return await HttpDelete<SuccessfulPrivateAddressRemove>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

    }
}
