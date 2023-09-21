using B2CLibrary.Connection;
using B2CLibrary.Models;
using Microsoft.Graph.Models;
using System;
using System.Threading.Tasks;

namespace B2CLibrary.Operations
{
    public sealed class ServicePrincipalAppRole
    {
        public async Task<AppRoleAssignmentCollectionResponse>
      GetBySpId(Karbonb2cConnection _client, string spid)
        {
            var _graphClient = _client.CreateGraphClient();
            return await _graphClient
                                        .ServicePrincipals[spid]
                                        .AppRoleAssignedTo
            .GetAsync();
        }

        public async Task<AppRoleAssignment>
        Create(Karbonb2cConnection _client, AssignRoleToServicePrincipal data)
        {
            try
            {
                var requestBody = new Microsoft.Graph.Models.AppRoleAssignment
                {
                    PrincipalId = Guid.Parse(data.PrincipalId),
                    ResourceId = Guid.Parse(data.ResourceId),
                    AppRoleId = Guid.Parse(data.ApplicationRoleId)
                };
                var _graphClient = _client.CreateGraphClient();
                return await _graphClient.ServicePrincipals[data.PrincipalId]
                    .AppRoleAssignedTo.PostAsync(requestBody);
            }
            catch (Microsoft.Graph.Models.ODataErrors.ODataError ex)
            {
                Console.WriteLine(ex.Error);
                Console.WriteLine(ex?.Error?.Message);
                throw;
            }
        }
    } // ServicePrincipalAppRole Class Ends
}
