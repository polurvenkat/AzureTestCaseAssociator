using System;
using AzureTestCaseAssociator.Core.Contract;
using AzureTestCaseAssociator.Core.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AzureTestCaseAssociator.Core.Contract
{
    public interface IAzureServiceManager
    {
        public Task<List<KeyValuePair<string, int>>> AssociateToTestCaseAsync(TestCaseDetailDto testCaseDetailDto, string devopsAccessToken);
    }
}