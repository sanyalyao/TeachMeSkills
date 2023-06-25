using home_19.BusinessObject.Models;
using home_19.BusinessObject.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace home_19.BusinessObject.ApiServiceStep
{
    public class ApiTestCaseSteps
    {
        protected TestCaseService TestCaseService;

        public ApiTestCaseSteps(TestCaseService testCaseService)
        {
            TestCaseService = testCaseService;
        }

        public List<TestCase> GetAllTestCasesSteps(string projectCode)
        {
            RestResponse response = TestCaseService.GetAllTestCases(projectCode);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<EntityCases<List<TestCase>>>>(response.Content).Result.Entities;
        }

        public void CreateTestCaseSteps(string projectCode, TestCase testCase)
        {
            RestResponse response = TestCaseService.CreateTestCase(projectCode, testCase);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);
        }

        public TestCase GetSpecificTestCaseSteps(string projectCode, TestCase testCase)
        {
            RestResponse response = TestCaseService.GetSpecificTestCase(projectCode, testCase);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<TestCase>>(response.Content).Result;
        }
    }
}
