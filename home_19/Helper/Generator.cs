using home_19.BusinessObject.Models;

namespace home_19.Helper
{
    public class Generator
    {
        public CreateProjectModel GenerateNewProject()
        {
            CreateProjectModel project = new CreateProjectModel()
            {
                Title = Faker.Company.Name(),
                Code = Faker.RandomNumber.Next().ToString(),
                Access = "none"
            };

            return project;
        }

        public TestCase GenerateTestCase(bool needId = false)
        {
            TestCase testCase = new TestCase()
            {
                Title = Faker.Company.Name(),
            };

            if (needId)
            {
                testCase.Id = Faker.RandomNumber.Next();
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
