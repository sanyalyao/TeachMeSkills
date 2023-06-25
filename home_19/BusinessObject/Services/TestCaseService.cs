using home_19.BusinessObject.Models;
using home_19.Core;
using RestSharp;

namespace home_19.BusinessObject.Services
{
    public class TestCaseService : BaseService
    {
        public string TestCaseEndpoint = "/case/{code}";
        public string SpecificTestCaseEndpoint = "/case/{code}/{id}";
        public string TestCasesInBulkEndpoint = "/case/{code}/bulk";

        public TestCaseService(BaseAPIClient apiClient) : base(apiClient) { }

        public RestResponse GetAllTestCases(string projectCode)
        {
            var request = new RestRequest(TestCaseEndpoint).AddUrlSegment("code", projectCode);

            return apiClient.Execute(request);
        }

        public RestResponse CreateTestCase(string projectCode, TestCase testCase)
        {
            var request = new RestRequest(TestCaseEndpoint, Method.Post).AddUrlSegment("code", projectCode);
            request.AddBody(testCase);

            return apiClient.Execute(request);
        }

        public RestResponse GetSpecificTestCase(string projectCode, TestCase testCase)
        {
            var request = new RestRequest(SpecificTestCaseEndpoint).AddUrlSegment("code", projectCode).AddUrlSegment("id", testCase.Id);

            return apiClient.Execute(request);
        }

        public RestResponse DeleteTestCase(string projectCode, int id)
        {
            var request = new RestRequest(SpecificTestCaseEndpoint, Method.Delete).AddUrlSegment("code", projectCode).AddUrlSegment("id", id);

            return apiClient.Execute(request);
        }

        public RestResponse UpdateTestCase(string projectCode, TestCase testCase, TestCase testCaseWithNewParameters)
        {
            var request = new RestRequest(SpecificTestCaseEndpoint, Method.Patch).AddUrlSegment("code", projectCode).AddUrlSegment("id", testCase.Id);
            request.AddBody(testCaseWithNewParameters);

            return apiClient.Execute(request);
        }

        public RestResponse CreateTestCasesInBulk(string projectCode, TestCases<List<TestCase>> testCases)
        {
            var request = new RestRequest(TestCasesInBulkEndpoint, Method.Post).AddUrlSegment("code", projectCode);
            request.AddBody(testCases);

            return apiClient.Execute(request);
        }
    }
}
