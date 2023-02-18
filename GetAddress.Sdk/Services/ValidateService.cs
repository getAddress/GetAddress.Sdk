using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class ValidateService: AddressService
    {
        public ValidateService(AddressLookupKey addressLookupKey, HttpClient httpClient = null) : base(addressLookupKey?.Key, httpClient)
        {
        }

        public async Task<Result<SuccessfulValidation>> Validate(string address,
            ValidateOptions options = default, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            options = options ?? new ValidateOptions();

            var path = GetPath(address);

            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulValidation>(requestUri, 
                data: options,
                administrationOrApiKey: AddressLookupKey, 
                token: accessToken, cancellationToken: cancellationToken);
        }

        private string GetPath(string term)
        {
            return $"Validate/{term}";
        }
    }
}
