using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class FindService : AddressService
    {
        public FindService(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public async Task<Result<SuccessfulFind>> Find(string postcode,
            FindOptions options = default, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            options = options ?? new FindOptions();

            var requestUri = GetFindUri(postcode, options);

            return await HttpGet<SuccessfulFind>(requestUri, administrationOrApiKey:ApiKey, token: accessToken, cancellationToken: cancellationToken);
        }

        private Uri GetFindUri(string postcode, FindOptions options)
        {
            var nameValues = new NameValueCollection();

            nameValues.Add("api-version", options.Version);

            nameValues.Add("expand", true.ToString());

            var path = GetPath(postcode, options);

            return GetUri(path, nameValues);
        }

        private string GetPath(string postcode, FindOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.HouseNameOrNumber))
            {
                return $"Find/{postcode}";
            }

            return $"Find/{postcode}/{options.HouseNameOrNumber}";
        }


    }
}
