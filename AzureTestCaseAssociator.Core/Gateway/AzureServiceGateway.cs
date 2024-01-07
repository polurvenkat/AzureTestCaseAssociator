using System;
using System.Net.Http;
using AzureTestCaseAssociator.Core.Contract;

namespace AzureTestCaseAssociator.Core.Gateway
{
    public class AzureServiceGateway : IAzureServiceGateway
    {
        private readonly HttpClient _httpClient;
        public AzureServiceGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public string GetAzureService()
        {
            return "AzureService";
        }
    }
}