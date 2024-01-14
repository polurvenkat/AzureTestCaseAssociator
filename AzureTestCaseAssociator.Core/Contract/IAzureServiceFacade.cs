using System;
using AzureTestCaseAssociator.Core.Contract;
using AzureTestCaseAssociator.Core.Dtos;

namespace AzureTestCaseAssociator.Core
{
    public interface IAzureServiceFacade
    {
        public Task<string> AssociateToTestCaseAsync(TestCaseDetailDto testCaseDetailDto, string devopsAccessToken);
    }
}