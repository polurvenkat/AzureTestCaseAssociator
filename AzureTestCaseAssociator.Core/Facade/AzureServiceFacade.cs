using AzureTestCaseAssociator.Core.Contract;
using AzureTestCaseAssociator.Core.Dtos;


namespace AzureTestCaseAssociator.Core.Facade
{
    public class AzureServiceFacade : IAzureServiceFacade
    {
        private readonly IAzureServiceGateway _azureServiceGateway;
        //private readonly IAzureServiceMapper _azureServiceMapper;

        public AzureServiceFacade(IAzureServiceGateway azureServiceGateway/*, IAzureServiceMapper azureServiceMapper*/)
        {
            _azureServiceGateway = azureServiceGateway;
            //_azureServiceMapper = azureServiceMapper;
        }

        public async Task<string> AssociateToTestCaseAsync(TestCaseDetailDto testCaseDetailDto, string devopsAccessToken)
        {
            //var testDto = _azureServiceMapper.MapToTestDto(testCaseDetailDto);
            var result = await _azureServiceGateway.AssociateToTestCaseAsync(testCaseDetailDto, devopsAccessToken);
            return result;
        }
    }
}