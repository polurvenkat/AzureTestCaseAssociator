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
        public async Task<string> AssociateToTestCaseAsync(TestCaseDetailDto testCaseDetailDto, string devopsAccessToken)
        {
           var testCaseDto = new List<TestDto>();

                testCaseDto.Add(new TestDto
                {
                    Op = "add",
                    Path = "/fields/Microsoft.VSTS.TCM.AutomatedTestName",
                    Value = testCaseDetailDto.TestCaseName
                });

                testCaseDto.Add(new TestDto
                {
                    Op = "add",
                    Path = "/fields/Microsoft.VSTS.TCM.AutomatedTestStorage",
                    Value = testCaseDetailDto.TestCasePath
                });

                testCaseDto.Add(new TestDto
                {
                    Op = "add",
                    Path = "/fields/Microsoft.VSTS.TCM.AutomatedTestId",
                    Value = testCaseDetailDto.TestCaseId
                });

                testCaseDto.Add(new TestDto
                {
                    Op = "add",
                    Path = "/fields/Microsoft.VSTS.TCM.AutomationStatus",
                    Value = testCaseDetailDto.TestCaseAutomationStatus
                });

                string[] testCaseIds = testCaseDetailDto?.TestCaseId?.Split('-');

                var request = DevopsUtilsFactory.GetDevOpsRequest(devopsAccessToken);

                request.Content = new StringContent(JsonConvert.SerializeObject(testCaseDto), Encoding.UTF8, "application/json-patch+json");

                if(testCaseIds?.Length > 0){
                     testCaseIds?.ToList().ForEach(async testCaseId =>
                        {
                            var formattedTestCaseId = string.Join(string.Empty, testCaseId.Where(char.IsDigit));

                            if(!string.IsNullOrEmpty(formattedTestCaseId) && int.TryParse(formattedTestCaseId, out int testcasewithId))
                            {
                                //request.RequestUri = new Uri($"{devopsUrl}/_apis/test/plans/{planId}/suites/{suiteId}/testcases/{testCaseId}?api-version=5.0");
                                var response = await _httpClient.SendAsync(request);
                                response.EnsureSuccessStatusCode();
                            }
                        });

                    return "Test case associated successfully";
                }
                else{
                    return "Test case id is null or empty";
                }
              
        }

        
    }
}