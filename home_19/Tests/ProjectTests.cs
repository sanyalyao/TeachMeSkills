using home_19.Helper;
using home_19.BusinessObject.Models;
using NUnit.Framework;
using RestSharp;
using System.Net;
using NUnit.Allure.Attributes;

namespace home_19.Tests
{
    public class ProjectTests : BaseTest
    {
        [Test]
        [Description("Get project by code")]
        [AllureOwner("Aleksandr")]
        [AllureTag("GetProjectByCode")]
        public void GetProjectByCode()
        {
            var response = projectService.GetProjectByCode(GetProject(0).Code);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        [Description("Get project by code with ResponseModel")]
        [AllureOwner("Aleksandr")]
        [AllureTag("GetProjectByCode_ResponseModel")]
        public void GetProjectByCode_ResponseModel()
        {
            var project = apiProjectSteps.GetProjectByCodeSteps(GetProject(0).Code);

            Console.WriteLine(project.Title);
        }

        [Test]
        [Description("Create project")]
        [AllureOwner("Aleksandr")]
        [AllureTag("CreateProject")]
        public void CreateProject()
        {
            var projectResponse = projectService.CreateProject(new Generator().GenerateNewProject());

            Assert.IsTrue(projectResponse.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        [Description("Get all projects")]
        [AllureOwner("Aleksandr")]
        [AllureTag("GetAllProjects")]
        public void GetAllProjects()
        {
            List<Project> projects = apiProjectSteps.GetProjectsSteps();

            projects.ForEach(project => Console.WriteLine(project.Title));
        }

        [Test]
        [Description("Delete project by code")]
        [AllureOwner("Aleksandr")]
        [AllureTag("DeleteProjectByCode")]
        public void DeleteProjectByCode()
        {
            RestResponse response = projectService.DeleteProjectByCode(GetProject(0).Code);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        [Description("Grant access to project by code")]
        [AllureOwner("Aleksandr")]
        [AllureTag("GrantAccessToProjectByCode")]
        public void GrantAccessToProjectByCode()
        {
            MemberModel member = new MemberModel()
            {
                MemberId = 1,
            };

            RestResponse response = projectService.GrantAccessToProjectByCode(GetProject(0).Code, member);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        [Description("Revoke access to project by code")]
        [AllureOwner("Aleksandr")]
        [AllureTag("RevokeAccessToProjectByCode")]
        public void RevokeAccessToProjectByCode()
        {
            MemberModel member = new MemberModel()
            {
                MemberId = 1,
            };

            RestResponse response = projectService.RevokeAccessToProjectByCode(GetProject(0).Code, member);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }
    }
}
