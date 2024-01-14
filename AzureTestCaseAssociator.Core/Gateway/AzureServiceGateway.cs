using System;
using System.Net.Http;
using AzureTestCaseAssociator.Core.Contract;
using AzureTestCaseAssociator.Core.Dtos;
using System.Threading.Tasks;
using AzureTestCaseAssociator.Core.Factory;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace AzureTestCaseAssociator.Core.Gateway
{
    /// <summary>
    /// Represents a gateway for interacting with Azure services.
    /// </summary>
    public class AzureServiceGateway : IAzureServiceGateway
    {
        private readonly HttpClient _httpClient;
        public AzureServiceGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// Associates a test case with the provided details to a test plan and suite in Azure DevOps.
        /// </summary>
        /// <param name="testCaseDetailDto">The details of the test case to associate.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a string indicating the success of the association.</returns>
        public async Task<string> AssociateToTestCaseAsync(HttpRequestMessage httpRequestMessage)
        {
            var response = await _httpClient.SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                return "Successfully associated the test case.";
            }
            else
            {
                return $"Failed to associate the test case. Status code: {response.StatusCode}";
            }
        }
    }
}