using B2CLibrary.Connection;
using B2CLibrary.Models;
using Microsoft.Graph.Models;
using System;
using System.Threading.Tasks;

namespace B2CLibrary.Operations
{
    public sealed class ClientSecret
    {
        public async Task<PasswordCredential> Create(Karbonb2cConnection _client, CreateSecret data)
        {
            try
            {
                var requestBody = new Microsoft.Graph.Applications.Item.AddPassword.AddPasswordPostRequestBody
                {
                    PasswordCredential = new PasswordCredential
                    {
                        DisplayName = data.Name,
                    },
                };
                var _graphClient = _client.CreateGraphClient();
                return await _graphClient.Applications[data.ApplicationObjectId].AddPassword.PostAsync(requestBody);
            }
            catch (Microsoft.Graph.Models.ODataErrors.ODataError ex)
            {
                Console.WriteLine(ex.Error);
                Console.WriteLine(ex?.Error?.Message);
                throw;
            }
        }
    } // ClientSecret Class Ends
}
