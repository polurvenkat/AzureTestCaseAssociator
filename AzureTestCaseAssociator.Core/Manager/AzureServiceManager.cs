using System;
using AzureTestCaseAssociator.Core.Contract;
using AzureTestCaseAssociator.Core.Dtos;
using System.Threading.Tasks;
using System.Linq;
using AzureTestCaseAssociator.Core.Factory;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;

namespace AzureTestCaseAssociator.Core.Manager
{
    public class AzureServiceManager : IAzureServiceManager
    {
        private readonly IAzureServiceGateway _azureServiceGateway;
        public AzureServiceManager(IAzureServiceGateway azureServiceGateway)
        {
            _azureServiceGateway = azureServiceGateway;
        }

        /// <summary>
        /// Associates the given test case details to a test case in Azure DevOps.
        /// </summary>
        /// <param name="testCaseDetailDto">The test case details to associate.</param>
        /// <param name="devopsAccessToken">The access token for Azure DevOps.</param>
        /// <returns>The result of the association operation.</returns>
        public async Task<List<KeyValuePair<string, int>>> AssociateToTestCaseAsync(TestCaseDetailDto testCaseDetailDto, string devopsAccessToken)
        {
            List<KeyValuePair<string, int>> keyValueList = new List<KeyValuePair<string, int>>();
            // if you have mutiple test cases to associate, you can split the test case id by '-' and then loop through the array to associate each test case
            string[] testCaseIds = testCaseDetailDto?.TestCaseId?.Split('-');

            if(testCaseIds.Length > 0){
                testCaseIds?.ToList().ForEach(async testCaseId =>
                {
                    var formattedTestCaseId = string.Join(string.Empty, testCaseId.Where(char.IsDigit));

                    if (!string.IsNullOrEmpty(formattedTestCaseId) && int.TryParse(formattedTestCaseId, out int testcasewithId))
                    {
                        // Get the devops request dto
                        var devopsRequestDto = DevopsUtilsFactory.GetDevOpsRequest(devopsAccessToken);

                        // Get the test case dto
                        var testCaseDetails = RequestBuilderFactory.GetRequestForTestCaseAssociation(testCaseDetailDto, testcasewithId);

                        devopsRequestDto.Content = new StringContent(JsonConvert.SerializeObject(testCaseDetails), Encoding.UTF8, "application/json-patch+json");

                        var result = await _azureServiceGateway.AssociateToTestCaseAsync(devopsRequestDto);

                        keyValueList.Add(new KeyValuePair<string, int>(result, testcasewithId));
                    }
                });
            }

            return keyValueList;
            
        }
    }
}