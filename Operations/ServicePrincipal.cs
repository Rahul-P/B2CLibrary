using B2CLibrary.Connection;
using B2CLibrary.Models;
using Microsoft.Graph.Models;
using System;
using System.Threading.Tasks;

namespace B2CLibrary.Operations
{
    public sealed class ServicePrincipal
    {
        public async Task<ServicePrincipalCollectionResponse>
        GetAll(Karbonb2cConnection _client)
        {
            var _graphClient = _client.CreateGraphClient();
            return await _graphClient.ServicePrincipals.GetAsync();
        }

        public async Task<Microsoft.Graph.Models.ServicePrincipal>
          GetByObjectId(Karbonb2cConnection _client, string id)
        {
            var _graphClient = _client.CreateGraphClient();
            return await _graphClient
                .ServicePrincipals[id] // This is the 'object Id' of App.
                .GetAsync();
        }


        public async Task<Microsoft.Graph.Models.ServicePrincipal>
            Create(Karbonb2cConnection _client, CreateServicePrincipal data)
        {
            try
            {
                var requestBody = new Microsoft.Graph.Models.ServicePrincipal
                {
                    AppId = data.ApplicationId,
                };
                var _graphClient = _client.CreateGraphClient();
                return await _graphClient.ServicePrincipals.PostAsync(requestBody);
            }
            catch (Microsoft.Graph.Models.ODataErrors.ODataError ex)
            {
                Console.WriteLine(ex.Error);
                Console.WriteLine(ex?.Error?.Message);
                throw;
            }
        }
    } // ServicePrincipal Class Ends
}
