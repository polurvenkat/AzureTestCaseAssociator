using System;
using System.Net.Http;
using AzureTestCaseAssociator.Core.Contract;
using AzureTestCaseAssociator.Core.Dtos;
using System.Threading.Tasks;

namespace AzureTestCaseAssociator.Core.Contract
{
    public interface IAzureServiceGateway
    {
        public Task<string> AssociateToTestCaseAsync(HttpRequestMessage httpRequestMessage);
    }
}