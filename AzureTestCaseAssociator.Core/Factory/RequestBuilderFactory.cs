using System.Collections.Generic;
using AzureTestCaseAssociator.Core.Dtos;


namespace AzureTestCaseAssociator.Core.Factory
{
    public static class RequestBuilderFactory 
    {
       public static List<TestDto> GetRequestForTestCaseAssociation(TestCaseDetailDto testCaseDetailDto, int testcasewithId)
       {
           var testDtos = new List<TestDto>();
           testDtos.Add(new TestDto
           {
               Op = "add",
               Path = "/fields/Microsoft.VSTS.TCM.AutomatedTestName",
               Value = testCaseDetailDto.TestCaseName
           });
           testDtos.Add(new TestDto
           {
               Op = "add",
               Path = "/fields/Microsoft.VSTS.TCM.AutomatedTestStorage",
               Value = testCaseDetailDto.AssemblyName
           });
           testDtos.Add(new TestDto
           {
               Op = "add",
               Path = "/fields/Microsoft.VSTS.TCM.AutomatedTestId",
               Value = testcasewithId.ToString()
           });
           testDtos.Add(new TestDto
           {
               Op = "add",
               Path = "/fields/Microsoft.VSTS.TCM.AutomatedTestType",
               Value = testCaseDetailDto.TestCaseType
           });
           testDtos.Add(new TestDto
           {
               Op = "add",
               Path = "/fields/Microsoft.VSTS.TCM.AutomationStatus",
               Value = testCaseDetailDto.TestCaseAutomationStatus
           });

           return testDtos;
       }
    }
}
