namespace AzureTestCaseAssociator.Core.Dtos
{
    public class TestCaseDetailDto
    {
        public string? TestCaseId { get; set; }
        public string? TestCaseName { get; set; }
        public string? AssemblyName { get; set; }
        public string? TestCasePriority { get; set; }
        public string? TestCaseSeverity { get; set; }
        public string? TestCaseType { get; set; }
        public string? TestCaseStatus { get; set; }
        public string? TestCaseAutomationStatus { get; set; }
    }
}