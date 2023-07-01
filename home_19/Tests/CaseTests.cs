using home_19.BusinessObject.Models;
using home_19.Helper;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace home_19.Tests
{
    public class CaseTests : BaseTest
    {
        [Test]
        [Description("Get all Test Cases")]
        [AllureOwner("Aleksandr")]
        [AllureTag("GetAllTestCases")]
        public void GetAllTestCases()
        {
            List<TestCase> testCases = apiTestCaseSteps.GetAllTestCasesSteps(GetProject(0).Code);

            testCases.ForEach(testCase => Console.WriteLine($"Id - {testCase.Id}\n" +
                $"Title - {testCase.Title}\n" +
                $"Description - {testCase.Description}"));
        }

        [Test]
        [Description("Create a new Test Case")]
        [AllureOwner("Aleksandr")]
        [AllureTag("CreateANewTestCase")]
        public void CreateANewTestCase()
        {
            TestCase testCase = new Generator().GenerateTestCase();
            testCase.Description = "erwogopwerg";

            apiTestCaseSteps.CreateTestCaseSteps(GetProject(0).Code, testCase);
        }

        [Test]
        [Description("Get specific Test Case")]
        [AllureOwner("Aleksandr")]
        [AllureTag("GetSpecificTestCase")]
        public void GetSpecificTestCase()
        {
            TestCase testCase = GetTestCase(0, 2);
            TestCase specificTestCase = apiTestCaseSteps.GetSpecificTestCaseSteps(GetProject(0).Code, testCase);

            Assert.AreEqual(testCase, specificTestCase);
        }

        [Test]
        [Description("Delete Test Case")]
        [AllureOwner("Aleksandr")]
        [AllureTag("DeleteTestCase")]
        public void DeleteTestCase()
        {
            RestResponse response = testCaseService.DeleteTestCase(GetProject(0).Code, GetTestCase(0, 0).Id);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        [Description("Update Test Case")]
        [AllureOwner("Aleksandr")]
        [AllureTag("UpdateTestCase")]
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
        [Description("Create Test Cases in Bulk")]
        [AllureOwner("Aleksandr")]
        [AllureTag("CreateTestCasesInBulk")]
        public void CreateTestCasesInBulk()
        {
            List<TestCase> listOfTestCases = new List<TestCase>
            {
                new Generator().GenerateTestCase(true),
                new Generator().GenerateTestCase(true),
                new Generator().GenerateTestCase(true)
            };

            var testCases = new Generator().GenerateTestCasesInBulk(listOfTestCases);
            var response = testCaseService.CreateTestCasesInBulk(GetProject(0).Code, testCases);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }
    }
}
