using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class EmailService : AdministrationService
    {
        private const string path = "email-address";
        public EmailService(string administrationKey, HttpClient httpClient = null) : base(administrationKey, httpClient)
        {

        }

        public async Task<Result<SuccessfulEmail>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpGet<SuccessfulEmail>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

        }

        public async Task<Result<SuccessfulEmailUpdate>> Update(UpdateEmail request,
            AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var result = await HttpPut<SuccessfulEmailUpdate>(requestUri,data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            if(result.IsSuccess && result.Success == null)
            {
                result.Success = new SuccessfulEmailUpdate();
            }

            return result;
        }
    }
}
