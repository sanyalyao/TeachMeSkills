using home_19.BusinessObject.Models;

namespace home_19.Helper
{
    public class Generator
    {
        private Random random = new Random();
        private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public CreateProjectModel GenerateNewProject(int length)
        {
            CreateProjectModel project = new CreateProjectModel()
            {
                Title = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray()),
                Code = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray()),
                Access = "none"
            };

            return project;
        }

        public TestCase GenerateTestCase(int lengthOfTitle, bool needId = false)
        {
            TestCase testCase = new TestCase()
            {
                Title = new string(Enumerable.Repeat(chars, lengthOfTitle).Select(s => s[random.Next(s.Length)]).ToArray()),
            };

            if (needId)
            {
                testCase.Id = random.Next(99, 999999);
            }

            return testCase;
        }

        public TestCases<List<TestCase>> GenerateTestCasesInBulk(List<TestCase> listOfTestCases)
        {
            TestCases<List<TestCase>> testCases = new TestCases<List<TestCase>>()
            {
                Cases = listOfTestCases
            };

            return testCases;
        }
    }
}
