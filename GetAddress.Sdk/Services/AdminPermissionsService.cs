using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class AdminPermissionsService : AdministrationService
    {
        private const string path = "security/admin-permissions";
        public AdminPermissionsService(AdministrationKey administrationKey, HttpClient httpClient = null) : base(administrationKey?.Key, httpClient)
        {

        }

        public async Task<Result<SuccessfulAdminPermissions[]>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return  await HttpGet<SuccessfulAdminPermissions[]>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulAdminPermissions>> Get(string name,AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var pathAndId = $"{path}/{name}";

            var requestUri = GetUri(pathAndId);

            return await HttpGet<SuccessfulAdminPermissions>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

        }

        public async Task<Result<SuccessfulAdminPermissionsAdd>> Add(AddAdminPermissions request,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            return await HttpPost<SuccessfulAdminPermissionsAdd>(requestUri, data: request, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulAdminPermissionRemove>> Remove(string name,
            AccessToken accessToken = default,
            CancellationToken cancellationToken = default)
        {
            var removePath = path + $"/{name}";

            var requestUri = GetUri(removePath);

            return await HttpDelete<SuccessfulAdminPermissionRemove>(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

        }

    }
}
