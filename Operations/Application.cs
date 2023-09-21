using B2CLibrary.Connection;
using B2CLibrary.Models;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace B2CLibrary.Operations
{
    public sealed class Application
    {
        public async Task<Microsoft.Graph.Models.ApplicationCollectionResponse>
        GetAll(Karbonb2cConnection _client)
        {

            var _graphClient = _client.CreateGraphClient();

            var fetchedApps = await _graphClient.Applications.GetAsync();
            return fetchedApps;
        }
        public async Task<Microsoft.Graph.Models.Application>
            GetByObjectId(Karbonb2cConnection _client, string id)
        {
            var _graphClient = _client.CreateGraphClient();
            return await _graphClient
                            .Applications[id] // This is the 'object Id' of App.
                            .GetAsync();
        }

        // Add Application
        public async Task<Microsoft.Graph.Models.Application>
            Create(Karbonb2cConnection _client, CreateApplication data)
        {
            try
            {
                var requestBody = new Microsoft.Graph.Models.Application
                {
                    DisplayName = data.Name
                };
                var _graphClient = _client.CreateGraphClient();
                return await _graphClient.Applications.PostAsync(requestBody);
            }
            catch (Microsoft.Graph.Models.ODataErrors.ODataError ex)
            {
                Console.WriteLine(ex.Error);
                Console.WriteLine(ex?.Error?.Message);
                throw;
            }
        }

        // Add Scopes/Roles
        public async Task<Microsoft.Graph.Models.Application>
            RequestRoles(Karbonb2cConnection _client, ReqRoles data)
        {
            try
            {
                List<ResourceAccess> _access = new List<ResourceAccess>();
                foreach (string roleId in data.RoleIds)
                {
                    _access.Add(new ResourceAccess
                    {
                        Id = new Guid(roleId),
                        Type = KConstants.Type_Role
                    });
                }

                var requestBody = new Microsoft.Graph.Models.Application
                {
                    RequiredResourceAccess = new List<Microsoft.Graph.Models.RequiredResourceAccess>
            {
              new RequiredResourceAccess
              {
                ResourceAppId = data.ResourceAppId,
                ResourceAccess = _access
              },
            }
                };
                var _graphClient = _client.CreateGraphClient();
                return await _graphClient.Applications[data.ApplicationId].PatchAsync(requestBody);
            }
            catch (Microsoft.Graph.Models.ODataErrors.ODataError ex)
            {
                Console.WriteLine(ex.Error);
                Console.WriteLine(ex?.Error?.Message);
                throw;
            }
        }

    } // Application Class Ends
}
