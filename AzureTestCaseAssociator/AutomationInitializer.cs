using AzureTestCaseAssociator.Core.Contract;
using AzureTestCaseAssociator.Core.Dtos;
namespace AzureTestCaseAssociator;

public class AutomationInitializer
{
    private readonly IAzureServiceFacade _azureServiceFacade;

    public AutomationInitializer(IAzureServiceFacade azureServiceFacade)
    {
        _azureServiceFacade = azureServiceFacade;
    }
    
    public async Task<List<KeyValuePair<string, int>>> AssociateToTestCaseAsync(TestCaseDetailDto testCaseDetailDto, string devopsAccessToken)
    {
        var result = await _azureServiceFacade.AssociateToTestCaseAsync(testCaseDetailDto, devopsAccessToken);
        return result;
    }
}
