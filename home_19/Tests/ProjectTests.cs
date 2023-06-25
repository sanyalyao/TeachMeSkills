using home_19.Helper;
using home_19.BusinessObject.Models;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace home_19.Tests
{
    public class ProjectTests : BaseTest
    {
        [Test]
        public void GetProjectByCode()
        {
            var response = projectService.GetProjectByCode(GetProject(0).Code);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        public void GetProjectByCode_ResponseModel()
        {
            var project = apiProjectSteps.GetProjectByCodeSteps(GetProject(0).Code);

            Console.WriteLine(project.Title);
        }

        [Test]
        public void CreateProject()
        {
            var projectResponse = projectService.CreateProject(new Generator().GenerateNewProject(8));

            Assert.IsTrue(projectResponse.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        public void GetAllProjects()
        {
            List<Project> projects = apiProjectSteps.GetProjectsSteps();

            projects.ForEach(project => Console.WriteLine(project.Title));
        }

        [Test]
        public void DeleteProjectByCode()
        {
            RestResponse response = projectService.DeleteProjectByCode(GetProject(0).Code);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
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
