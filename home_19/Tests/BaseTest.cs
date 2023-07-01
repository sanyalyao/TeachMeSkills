using Allure.Net.Commons;
using home_19.BusinessObject.ApiServiceStep;
using home_19.BusinessObject.Models;
using home_19.BusinessObject.Services;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace home_19.Tests
{
    [AllureNUnit]
    public class BaseTest : BaseApiTest
    {
        protected TestCaseService testCaseService;
        protected ApiTestCaseSteps apiTestCaseSteps;
        protected ProjectService projectService;
        protected ApiProjectSteps apiProjectSteps;
        protected AllureLifecycle Allure;

        [OneTimeSetUp]
        public void InitialService()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();

            testCaseService = new TestCaseService(apiClient);
            apiTestCaseSteps = new ApiTestCaseSteps(testCaseService);
            projectService = new ProjectService(apiClient);
            apiProjectSteps = new ApiProjectSteps(projectService);
        }

        [SetUp]
        public void SetUp()
        {
            Allure = AllureLifecycle.Instance;
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
