using home_19.BusinessObject.Models;
using home_19.Helper;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace home_19.Tests
{
    public class CaseTests : BaseTest
    {
        [Test]
        public void GetAllTestCases()
        {
            List<TestCase> testCases = apiTestCaseSteps.GetAllTestCasesSteps(GetProject(0).Code);

            testCases.ForEach(testCase => Console.WriteLine($"Id - {testCase.Id}\n" +
                $"Title - {testCase.Title}\n" +
                $"Description - {testCase.Description}"));
        }

        [Test]
        public void CreateANewTestCase()
        {
            TestCase testCase = new Generator().GenerateTestCase(6);
            testCase.Description = "erwogopwerg";

            apiTestCaseSteps.CreateTestCaseSteps(GetProject(0).Code, testCase);
        }

        [Test]
        public void GetSpecificTestCase()
        {
            TestCase testCase = GetTestCase(0, 2);
            TestCase specificTestCase = apiTestCaseSteps.GetSpecificTestCaseSteps(GetProject(0).Code, testCase);

            Assert.AreEqual(testCase, specificTestCase);
        }

        [Test]
        public void DeleteTestCase()
        {
            RestResponse response = testCaseService.DeleteTestCase(GetProject(0).Code, GetTestCase(0, 0).Id);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        public void UpdateTestCase()
        {
            TestCase testCaseWithNewParameters = new TestCase()
            {
                Description = "new description",
                Title = "title",
            };

            var response = testCaseService.UpdateTestCase(GetProject(0).Code, GetTestCase(0, 0), testCaseWithNewParameters);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        public void CreateTestCasesInBulk()
        {
            List<TestCase> listOfTestCases = new List<TestCase>
            {
                new Generator().GenerateTestCase(5, true),
                new Generator().GenerateTestCase(8, true),
                new Generator().GenerateTestCase(10, true)
            };

            var testCases = new Generator().GenerateTestCasesInBulk(listOfTestCases);
            var response = testCaseService.CreateTestCasesInBulk(GetProject(0).Code, testCases);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }
    }
}
