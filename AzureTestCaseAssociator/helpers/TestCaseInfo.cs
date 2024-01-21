using System;
using System.Data;

namespace AzureTestCaseAssociator.Helpers
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class TestCaseInfo : Attribute
    {
        private List<int> _testCaseId;
        private string _fullQualifiedName;
        private string _assemblyName;
        private int _testPlanId;
        private int _testSuiteId;
        private bool _isSkipped;
        private string? _skipReason;

        public TestCaseInfo(List<int> testCaseId, string fullQualifiedName, string assemblyName, int testPlanId, int testSuiteId, bool isSkipped, string? skipReason)
        {
            _testCaseId = testCaseId;
            _fullQualifiedName = fullQualifiedName;
            _assemblyName = assemblyName;
            _testPlanId = testPlanId;
            _testSuiteId = testSuiteId;
            _isSkipped = isSkipped;
            _skipReason = skipReason;
        }

        public List<int> TestCaseId
        {
            get { return _testCaseId; }
        }

        public string FullQualifiedName
        {
            get { return _fullQualifiedName; }
        }

        public string AssemblyName
        {
            get { return _assemblyName; }
        }

        public int TestPlanId
        {
            get { return _testPlanId; }
        }

        public int TestSuiteId
        {
            get { return _testSuiteId; }
        }   

        public bool IsSkipped
        {
            get { return _isSkipped; }
        }   

        public string? SkipReason
        {
            get { return _skipReason; }
        }
    }
}