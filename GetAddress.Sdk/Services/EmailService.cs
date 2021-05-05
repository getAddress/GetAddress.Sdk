using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Sdk.Services
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

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulEmail>();
        }

        public async Task<Result<SuccessfulEmailUpdate>> Update(UpdateEmailRequest request,
            AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var content = request.ToHttpContent();

            var response = await HttpPut(requestUri,httpContent: content, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            var result = await response.ToResult<SuccessfulEmailUpdate>();

            if(result.IsSuccess && result.Success == null)
            {
                result.Success = new SuccessfulEmailUpdate();
            }

            return result;
        }
    }
}
