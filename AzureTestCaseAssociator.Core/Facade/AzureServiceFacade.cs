using AzureTestCaseAssociator.Core.Contract;
using AzureTestCaseAssociator.Core.Dtos;
using System.Collections.Generic;
using AzureTestCaseAssociator.Core.Manager;
using System.Threading.Tasks;

namespace AzureTestCaseAssociator.Core.Facade
{
    public class AzureServiceFacade : IAzureServiceFacade
    {
        private readonly IAzureServiceManager _azureServiceManager;

        public AzureServiceFacade(IAzureServiceManager azureServiceManager)
        {
            _azureServiceManager = azureServiceManager;
        }

        public async Task<List<KeyValuePair<string, int>>> AssociateToTestCaseAsync(TestCaseDetailDto testCaseDetailDto, string devopsAccessToken)
        {
            var result = await _azureServiceManager.AssociateToTestCaseAsync(testCaseDetailDto, devopsAccessToken);
            return result;
        }
    }
}