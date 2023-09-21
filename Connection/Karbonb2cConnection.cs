using Azure.Identity;
using Microsoft.Graph;

namespace B2CLibrary.Connection
{
    public sealed class Karbonb2cConnection
    {
        public string _clientId { get; private set; }
        public string _tenantId { get; private set; }
        public string _clientSecret { get; private set; }

        private Karbonb2cConnection(string _passedClientId, string _passedTenantId, string _passedClientSecret)
        {
            this._clientId = _passedClientId;
            this._tenantId = _passedTenantId;
            this._clientSecret = _passedClientSecret;
        }

        // Keep connection count here, if you like.
        public static Karbonb2cConnection GetConnection
            (string _pClientId, string _pTenantId, string _pClientSecret)
            => new Karbonb2cConnection(_pClientId, _pTenantId, _pClientSecret);
    }

    public static class MakeConnection
    {
        public static GraphServiceClient CreateGraphClient(this Karbonb2cConnection _conn)
        {
            var options = new ClientSecretCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
            };
            var clientSecretCredential = new ClientSecretCredential(
                _conn._tenantId, _conn._clientId, _conn._clientSecret, options);

            var graphClient = new GraphServiceClient(clientSecretCredential, KConstants.KarbonDefaultScopes);
            return graphClient;
        }
    }
}
