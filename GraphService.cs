using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using SimpleGraphClient.Models;

namespace SimpleGraphClient
{
    public class GraphService : IGraphService
    {
        private readonly AzureAdOptions _azureOptions;
        private readonly ServiceAccountOptions _serviceAccount;
        private readonly GraphServiceClient _graphClient;

        public GraphService(IOptions<AzureAdOptions> azureOptions, IOptions<ServiceAccountOptions> serviceAccount)
        {
            _azureOptions = azureOptions.Value;
            _serviceAccount = serviceAccount.Value;

            var credential = new UsernamePasswordCredential(_serviceAccount.Username, _serviceAccount.Password, _azureOptions.TenantId, _azureOptions.ClientId);

            _graphClient = new GraphServiceClient(credential, _azureOptions.Scopes);
        }

        public async Task<User?> Me()
        {
            return await _graphClient.Me.GetAsync();
        }
    }
}
