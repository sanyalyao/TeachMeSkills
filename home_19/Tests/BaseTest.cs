using home_19.BusinessObject.ApiServiceStep;
using home_19.BusinessObject.Models;
using home_19.BusinessObject.Services;
using NUnit.Framework;

namespace home_19.Tests
{
    public class BaseTest : BaseApiTest
    {
        protected TestCaseService testCaseService;
        protected ApiTestCaseSteps apiTestCaseSteps;
        protected ProjectService projectService;
        protected ApiProjectSteps apiProjectSteps;

        [OneTimeSetUp]
        public void InitialService()
        {
            testCaseService = new TestCaseService(apiClient);
            apiTestCaseSteps = new ApiTestCaseSteps(testCaseService);
            projectService = new ProjectService(apiClient);
            apiProjectSteps = new ApiProjectSteps(projectService);
        }

        public Project GetProject(int project)
        {
            List<Project> projects = apiProjectSteps.GetProjectsSteps();

            return projects[project];
        }

        public TestCase GetTestCase(int project, int testcase)
        {
            List<TestCase> testCases = apiTestCaseSteps.GetAllTestCasesSteps(GetProject(project).Code);

            return testCases[testcase];
        }
    }
}
